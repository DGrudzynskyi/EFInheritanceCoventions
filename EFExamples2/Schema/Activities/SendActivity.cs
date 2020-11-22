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
            Parcel parcel,
            Werehouse targetWerehouse,
            decimal? deliveryFee = null,
            DateTime? sendDate = null) : base(parcel.Werehouse, parcel, sendDate)
        {
            AdditionaldDeliveryFee = deliveryFee;
            SentToWerehouse = targetWerehouse;
        }

        public decimal? AdditionaldDeliveryFee { get; protected set; }

        public Werehouse SentToWerehouse { get; protected set; }

        public override Parcel Apply()
        {
            var canBeSent = Parcel.PickActivity().GetType() == typeof(ReadyForSendActivity);
            if (!canBeSent) {
                throw new InvalidOperationException("parcel is not ready to for delivery");
            }

            Parcel.Werehouse = null;

            if (AdditionaldDeliveryFee.HasValue)
            {
                Parcel.DeliveryFee += AdditionaldDeliveryFee.Value;
            }

            return this.Parcel;
        }

        public override void Undo()
        {
            base.Undo();
            Parcel.Werehouse = Werehouse;

            if (AdditionaldDeliveryFee.HasValue)
            {
                Parcel.DeliveryFee -= AdditionaldDeliveryFee.Value;
            }
        }
    }
}
