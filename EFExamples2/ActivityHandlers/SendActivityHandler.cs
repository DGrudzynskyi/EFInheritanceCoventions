using EFExamples2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.ActivityHandlers
{
    public class SendActivityHandler : IActivityHandler
    {
        public Parcel Apply(Parcel parcel, Activity parcelActivity)
        {
            parcel.Werehouse = null;
            var activity = parcelActivity as SendActivity;
            if (activity.AdditionaldDeliveryFee.HasValue) {
                parcel.DeliveryFee += activity.AdditionaldDeliveryFee.Value;
            }
            
            parcel.Activities.Add(activity);
            return parcel;
        }

        public Parcel Revert(Activity parcelActivity)
        {
            var activity = parcelActivity as SendActivity;
            activity.Parcel.Werehouse = activity.Werehouse;
            if (activity.AdditionaldDeliveryFee.HasValue)
            {
                activity.Parcel.DeliveryFee -= activity.AdditionaldDeliveryFee.Value;
            }
            activity.IsReverted = true;
            return activity.Parcel;
        }
    }
}
