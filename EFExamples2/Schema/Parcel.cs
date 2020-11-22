using EFExamples2.CustomConvention;
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
        public int Id { get; set; }

        //[Precision(12, 2)]
        public decimal Value { get; set; }

        public decimal Weight { get; set; }

        // атрибут, обслуживаемый кастомным конвеншном
        // [Precision(12, 2)]
        public decimal DeliveryFee { get; set; }

        public virtual Werehouse Werehouse { get; set; }

        public virtual Werehouse TargetWerehouse { get; set; }

        // полиморфная ассоциация (TPH, TPT)
        public virtual List<Activity> Activities { get; set; }

        // не-полиморфная ассоциация (TPCT)
        // public List<CreateActivity> CreateActivities { get; set; }
        // public List<SendActivity> SendActivities { get; set; }
        // public List<ReadyForSendActivity> ReadyForSendActivities { get; set; }
        // public List<RetrieveActivity> RetriesveActivities { get; set; }

        public class ParcelConfiguration : EntityTypeConfiguration<Parcel>
        {
            public ParcelConfiguration()
            {
                Property(p => p.DeliveryFee);
            }
        }
    }
}
