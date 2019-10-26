using EFExamples2.ActivityHandlers;
using EFExamples2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2
{
    public static class DeliverySteps
    {
        public static void RetreivedByCustoms() {
            using (var ctx = new EFExamples2Context()) {
                var parcel = ctx.Parcels.Find(1);
                var customs = ctx.Werehouses.Single(x => x.Name == "Customs");
                var lastActivity = parcel.Activities.OrderByDescending(x => x.Timestamp).First();

                var retrieveActivity = new RetrieveActivity()
                {
                    Werehouse = customs,
                    Timestamp = lastActivity.Timestamp.AddDays(1),
                };

                var handlerFactory = new ActivityHandlersFactory();
                handlerFactory.GetActivityHandler(retrieveActivity).Apply(parcel, retrieveActivity);

                ctx.SaveChanges();
            }
        }

        public static void ProcessedAndSentByCustoms()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.Find(1);
                var customs = ctx.Werehouses.Single(x => x.Name == "Customs");
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
                };

                var handlerFactory = new ActivityHandlersFactory();
                handlerFactory.GetActivityHandler(readyActivity).Apply(parcel, readyActivity);
                handlerFactory.GetActivityHandler(sendActivity).Apply(parcel, sendActivity);

                ctx.SaveChanges();
            }
        }

        public static void RevertLastActivity()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.Find(1);
                var lastActivity = parcel.Activities.OrderByDescending(x => x.Timestamp).First();

                var handlerFactory = new ActivityHandlersFactory();
                var handler = handlerFactory.GetActivityHandler(lastActivity);
                handler.Revert(lastActivity);

                ctx.SaveChanges();
            }
        }
    }
}
