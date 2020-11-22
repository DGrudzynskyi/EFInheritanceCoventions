using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class ReadyForSendActivity : Activity
    {
        public ReadyForSendActivity() : base()
        {
        }

        public ReadyForSendActivity(Parcel parcel, DateTime? readyForSendDate = null) : base(parcel.Werehouse, parcel, readyForSendDate)
        {
        }

        public override Parcel Apply()
        {
            if (Parcel.Werehouse == null)
            {
                throw new InvalidOperationException("Parcel does not belongs to any werehouse. most likely it hasn't been received yet");
            }

            return this.Parcel;
        }

        public override void Undo()
        {
            base.Undo();

            IsReverted = true;
        }
    }
}
