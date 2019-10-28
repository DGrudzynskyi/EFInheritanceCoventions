﻿using EFExamples2.CustomConvention;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class Parcel
    {
        public Parcel() { }

        public Parcel(decimal value, decimal weight, Werehouse werehouse) {
            this.Value = value;
            this.Weight = weight;
            this.TargetWerehouse = werehouse;
        }

        public int Id { get; protected set; }

        [Precision(10, 2)]
        public decimal Value { get; protected set; }

        [Precision(10, 3)]
        public decimal Weight { get; protected set; }

        [Precision(10, 2)]
        public decimal DeliveryFee { get; set; }

        public virtual Werehouse Werehouse { get; set; }

        public virtual Werehouse TargetWerehouse { get; protected set; }

        public virtual List<Activity> Activities { get; protected set; }

        protected bool Cancelled { get; set; }

        public void Cancell() {
            if (this.Activities.Any(x => !x.IsReverted)) {
                throw new InvalidOperationException();
            }

            this.Cancelled = true;
        }

        public void TrackActivity(Activity activity) {
            this.Activities.Add(activity);
            activity.Apply();
        }

        public Activity PickActivity() {
            return this.Activities.OrderByDescending(x => x.Timestamp).First(x => !x.IsReverted);
        }
    }
}
