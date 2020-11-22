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

        public RetrieveActivity(Werehouse werehouse, Parcel parcel, DateTime? retreiveDate = null) : base(werehouse, parcel, retreiveDate) {
        }

        public override Parcel Apply()
        {
            var lastActivity = Parcel.PickActivity() as SendActivity;
            if (lastActivity == null)
            {
                throw new InvalidOperationException("unable to receive parcel which is not yet being delivered");
            }

            if (lastActivity.SentToWerehouse != this.Werehouse) {
                throw new InvalidOperationException("Brave yourself! Parcel has been delivered to wrong werehouse");
            }

            Parcel.Werehouse = this.Werehouse;
            return this.Parcel;
        }

        public override void Undo()
        {
            base.Undo();

            Parcel.Werehouse = null;
        }
    }
}
