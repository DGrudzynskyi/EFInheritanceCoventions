using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class RetrieveActivity : Activity
    {
        public RetrieveActivity() : base() {
        }

        public RetrieveActivity(Werehouse werehouse, Parcel parcel) : base(werehouse, parcel) {
        }

        public override Parcel Apply()
        {
            Timestamp = DateTime.Now;
            Parcel.Werehouse = this.Werehouse;
            return this.Parcel;
        }

        public override void Undo()
        {
            Parcel.Werehouse = null;
            IsReverted = true;
        }
    }
}
