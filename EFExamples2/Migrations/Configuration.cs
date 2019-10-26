namespace EFExamples2.Migrations
{
    using EFExamples2.Schema;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFExamples2.EFExamples2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFExamples2.EFExamples2Context context)
        {
            var stockholm = new Werehouse()
            {
                Id = 1,
                City = "Stockholm",
                Name = "Stockholm 1",
            };

            var wroclav = new Werehouse()
            {
                Id = 2,
                City = "Wroclav",
                Name = "Meest Express Werehouse",
            };

            var customs = new Werehouse()
            {
                Id = 3,
                City = "Dolgobichuv",
                Name = "Customs",
            };

            var kyiv = new Werehouse()
            {
                Id = 4,
                City = "Kyiv",
                Name = "Kyiv 1",
            };

            context.Werehouses.Add(stockholm);
            context.Werehouses.Add(wroclav);
            context.Werehouses.Add(customs);
            context.Werehouses.Add(kyiv);

            var tufli = new Parcel()
            {
                Weight = 1.4m,
                DeliveryFee = 6m,
                Id = 1,
                Value = 120,
            };

            var createTufli = new CreateActivity()
            {
                Id = 1,
                ExpectedDeliveryFee = 6,
                Parcel = tufli,
                Price = 120,
                Timestamp = new DateTime(2019, 9, 10),
                Werehouse = stockholm,
                Weight = 1.4m,
                TargetWerehouse = kyiv
            };

            var readyForDeliveryToMeest = new ReadyForSendActivity()
            {
                Parcel = tufli,
                Werehouse = stockholm,
                Timestamp = new DateTime(2019, 9, 10, 0, 0, 1),
            };

            var sentToMeest = new SendActivity()
            {
                Parcel = tufli,
                Werehouse = stockholm,
                Timestamp = new DateTime(2019, 9, 10, 0, 0, 2),
                SentToWerehouse = wroclav,
            };

            var retreivedByMeest = new RetrieveActivity()
            {
                Parcel = tufli,
                Werehouse = wroclav,
                Timestamp = new DateTime(2019, 9, 12),
            };

            var readyForDeliveryToCustoms = new ReadyForSendActivity()
            {
                Parcel = tufli,
                Werehouse = wroclav,
                Timestamp = new DateTime(2019, 9, 13),
            };

            var sentToCustoms = new SendActivity()
            {
                Parcel = tufli,
                Werehouse = wroclav,
                Timestamp = new DateTime(2019, 9, 13),
                SentToWerehouse = customs,
            };


            context.Parcels.Add(tufli);

            context.Activities.Add(createTufli);
            context.Activities.Add(readyForDeliveryToMeest);
            context.Activities.Add(sentToMeest);
            context.Activities.Add(retreivedByMeest);
            context.Activities.Add(readyForDeliveryToCustoms);
            context.Activities.Add(sentToCustoms);
        }
    }
}
