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
                var lastActivity = parcel.PickActivity();

                var retrieveActivity = new RetrieveActivity(customs, parcel);
                retrieveActivity.Timestamp = lastActivity.Timestamp.AddDays(1);

                parcel.TrackActivity(retrieveActivity);

                ctx.SaveChanges();
            }
        }

        public static void ProcessedAndSentByCustoms()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.Find(1);
                var customs = ctx.Werehouses.Single(x => x.Name == "Customs");
                var lastActivity = parcel.PickActivity();

                var readyActivity = new ReadyForSendActivity(customs, parcel);
                readyActivity.Timestamp = lastActivity.Timestamp.AddDays(1);

                var sendActivity = new ReadyForSendActivity(customs, parcel);
                sendActivity.Timestamp = lastActivity.Timestamp.AddDays(1).AddHours(1);

                parcel.TrackActivity(readyActivity);
                parcel.TrackActivity(sendActivity);

                ctx.SaveChanges();
            }
        }

        public static void RevertLastActivity()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.Find(1);
                var lastActivity = parcel.PickActivity();
                lastActivity.Undo();
                ctx.SaveChanges();
            }
        }
    }
}
