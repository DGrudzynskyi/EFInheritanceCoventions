using EFExamples2.ActivityHandlers;
using EFExamples2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2
{
    public static class DeliveryStepsBold
    {
        public static void RetreivedByCustoms() {
            using (var ctx = new EFExamples2Context()) {
                var parcel = ctx.Parcels.First();
                var customs = ctx.Werehouses.Single(x => x.Name == "Customs");
                var lastActivity = parcel.Activities.OrderByDescending(x => x.Timestamp).First();

                var sentActivity = lastActivity as SendActivity;
                if (sentActivity == null)
                {
                    throw new NotImplementedException("Unable to retreive the parcell which was never sent");
                }
                if (sentActivity.SentToWerehouse != customs)
                {
                    throw new NotImplementedException("parcel has been delivered to wrong werehouse!");
                }

                var retrieveActivity = new RetrieveActivity()
                {
                    Werehouse = customs,
                    Timestamp = lastActivity.Timestamp.AddDays(1),
                };

                parcel.Werehouse = customs;
                parcel.Activities.Add(retrieveActivity);

                ctx.SaveChanges();
            }
        }

        public static void ProcessedAndSentByCustoms()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.First();
                var customs = ctx.Werehouses.Single(x => x.Name == "Customs");
                var kyiv = ctx.Werehouses.Single(x => x.City == "Kyiv");
                var lastActivity = parcel.Activities.OrderByDescending(x => x.Timestamp).First();

                var readyActivity = new ReadyForSendActivity()
                {
                    Werehouse = customs,
                    Timestamp = lastActivity.Timestamp.AddDays(1),
                };

                var sendActivity = new SendActivity()
                {
                    Werehouse = customs,
                    Timestamp = lastActivity.Timestamp.AddDays(1).AddHours(1),
                    SentToWerehouse = kyiv,
                    AdditionaldDeliveryFee = 4m,
                };

                parcel.Activities.Add(readyActivity);
                parcel.Activities.Add(sendActivity);

                parcel.Werehouse = null;
                parcel.DeliveryFee += 4m;


                ctx.SaveChanges();
            }
        }

        public static void RevertLastActivity()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.First();
                var lastActivity = parcel.Activities.OrderByDescending(x => x.Timestamp).First();
                var previousActivity = parcel.Activities.OrderByDescending(x => x.Timestamp).Skip(1).First();

                var typeOfTheLastActivity = lastActivity.GetType().Name;

                switch (typeOfTheLastActivity) {
                    case "SendActivity":
                        parcel.Werehouse = lastActivity.Werehouse;
                        parcel.DeliveryFee -= (lastActivity as SendActivity).AdditionaldDeliveryFee.Value;
                        break;

                    case "ReadyForSend":
                        // apply reready-for-send-specific actions
                        break;

                    case "Retrieve":
                        // apply send-specific delivery actions
                        break;
                }

                ctx.SaveChanges();
            }
        }
    }
}
