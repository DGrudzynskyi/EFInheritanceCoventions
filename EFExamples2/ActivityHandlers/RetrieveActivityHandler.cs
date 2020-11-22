using EFExamples2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.ActivityHandlers
{
    public class RetrieveActivityHandler : IActivityHandler
    {
        public Parcel Apply(Parcel parcel, Activity activity)
        {
            var lastActivity = parcel.Activities.OrderByDescending(x => x.Timestamp).First();
            var sentActivity = lastActivity as SendActivity;
            if (sentActivity == null) {
                throw new NotImplementedException("Unable to retreive the parcell which was never sent");
            }
            if (sentActivity.SentToWerehouse != activity.Werehouse)
            {
                throw new NotImplementedException("parcel has been delivered to wrong werehouse!");
            }

            parcel.Werehouse = activity.Werehouse;
            parcel.Activities.Add(activity);
            return parcel;
        }

        public Parcel Revert(Activity activity)
        {
            activity.Parcel.Werehouse = null;
            activity.IsReverted = true;
            return activity.Parcel;
        }
    }
}
