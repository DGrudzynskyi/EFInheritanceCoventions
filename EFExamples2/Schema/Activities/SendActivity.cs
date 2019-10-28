using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class SendActivity : Activity
    {
        public SendActivity() : base() {

        }

        public SendActivity(
            Werehouse werehouse,
            Parcel parcel,
            Werehouse targetWerehouse,
            decimal? deliveryFee = null) : base(werehouse, parcel)
        {
            AdditionaldDeliveryFee = deliveryFee;
            SentToWerehouse = targetWerehouse;
        }

        public decimal? AdditionaldDeliveryFee { get; set; }

        public Werehouse SentToWerehouse { get; set; }

        public override Parcel Apply()
        {
            Timestamp = DateTime.Now;
            Parcel.Werehouse = null;

            if (AdditionaldDeliveryFee.HasValue)
            {
                Parcel.DeliveryFee += AdditionaldDeliveryFee.Value;
            }

            return this.Parcel;
        }

        public override void Undo()
        {
            Parcel.Werehouse = Werehouse;

            if (AdditionaldDeliveryFee.HasValue)
            {
                Parcel.DeliveryFee -= AdditionaldDeliveryFee.Value;
            }

            IsReverted = true;
        }
    }
}
