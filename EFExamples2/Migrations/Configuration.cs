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

            var createTufli = new CreateActivity(stockholm, 120, 1.4m, 6m, kyiv, new DateTime(2019, 9, 10));

            var tufli = createTufli.Apply();

            var readyForDeliveryToMeest = new ReadyForSendActivity(tufli, new DateTime(2019, 9, 10, 0, 0, 1));

            var sentToMeest = new SendActivity(tufli, wroclav, null, new DateTime(2019, 9, 10, 0, 0, 2));

            var retreivedByMeest = new RetrieveActivity(wroclav, tufli, new DateTime(2019, 9, 12));

            var readyForDeliveryToCustoms = new ReadyForSendActivity(tufli, new DateTime(2019, 9, 13));

            var sentToCustoms = new SendActivity(tufli, customs, null, new DateTime(2019, 9, 13, 1, 0, 0));


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
