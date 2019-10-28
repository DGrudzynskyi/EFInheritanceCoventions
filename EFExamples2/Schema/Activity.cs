using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public abstract class Activity
    {
        public Activity() {
        }

        public Activity(Werehouse werehouse, Parcel parcel = null) {
            Timestamp = DateTime.Now;
            Werehouse = werehouse;
            Parcel = parcel;
        }

        public int Id { get; protected set; }

        public DateTime Timestamp { get; set; }

        public virtual Parcel Parcel { get; protected set; }

        public virtual Werehouse Werehouse { get; protected set; }

        public bool IsReverted { get; protected set; }

        public abstract Parcel Apply();

        public abstract void Undo();
    }
}
