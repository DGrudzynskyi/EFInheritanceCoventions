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
