using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class CreateActivity : Activity
    {
        public CreateActivity() : base() {
        }

        public CreateActivity(
            Werehouse werehouse, 
            decimal price, 
            decimal weight, 
            decimal deliveryFee, 
            Werehouse targetWerehouse) : base(werehouse) {
            Price = price;
            Weight = weight;
            ExpectedDeliveryFee = deliveryFee;
            TargetWerehouse = targetWerehouse;
        }

        public decimal Price { get; protected set; }

        public decimal Weight { get; protected set; }

        public decimal ExpectedDeliveryFee { get; protected set; }

        public Werehouse TargetWerehouse { get; protected set; }

        public override Parcel Apply()
        {
            var parcel = new Parcel(Price, Weight, TargetWerehouse);
            parcel.DeliveryFee = ExpectedDeliveryFee;
            parcel.Werehouse = Werehouse;
            Timestamp = DateTime.Now;

            return parcel;
        }

        public override void Undo()
        {
            IsReverted = true;
            Parcel.Cancell();
        }
    }
}
