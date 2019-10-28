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

        public ReadyForSendActivity(Werehouse werehouse, Parcel parcel) : base(werehouse, parcel)
        {
        }

        public override Parcel Apply()
        {
            Timestamp = DateTime.Now;
            return this.Parcel;
        }

        public override void Undo()
        {
            IsReverted = true;
        }
    }
}
