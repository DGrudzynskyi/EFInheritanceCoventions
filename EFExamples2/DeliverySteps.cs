using EFExamples2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2
{
    public class DeliveryService
    {
        public void RetreivedByCustoms() {
            using (var ctx = new EFExamples2Context()) {
                var parcel = ctx.Parcels.First();
                var customs = ctx.Werehouses.Single(x => x.Name == "Customs");

                var retrieveActivity = new RetrieveActivity(customs,parcel,DateTime.Now.AddDays(-1));

                parcel.TrackActivity(retrieveActivity);

                ctx.SaveChanges();
            }
        }

        public void ProcessedAndSentByCustoms()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.First();

                var readyActivity = new ReadyForSendActivity(parcel, DateTime.Now.AddDays(-1));

                var kyiv = ctx.Werehouses.Single(x => x.City == "Kyiv");
                var sendActivity = new SendActivity(parcel, kyiv, 10m, DateTime.Now.AddDays(-1).AddHours(1));

                parcel.TrackActivity(readyActivity);
                parcel.TrackActivity(sendActivity);

                ctx.SaveChanges();
            }
        }

        public void RevertLastActivity()
        {
            using (var ctx = new EFExamples2Context())
            {
                var parcel = ctx.Parcels.First();
                var lastActivity = parcel.PickActivity();
                lastActivity.Undo();
                ctx.SaveChanges();
            }
        }
    }
}
