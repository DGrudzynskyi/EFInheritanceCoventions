
using EFExamples2.CustomConvention;
using EFExamples2.Schema;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFExamples2
{
    public class EFExamples2Context : DbContext
    {
        public DbSet<Werehouse> Werehouses { get; set; }

        public DbSet<Parcel> Parcels { get; set; }

        // this DbSet is required for TPH and TPT inheritance strategies
        public DbSet<Activity> Activities { get; set; }

        // four DBSets below are required for TPCT inheritance strategy
        //public DbSet<CreateActivity> CreateActivities { get; set; }
        //public DbSet<SendActivity> SendActivities { get; set; }
        //public DbSet<ReadyForSendActivity> ReadyForSendActivities { get; set; }
        //public DbSet<RetrieveActivity> RetriesveActivities { get; set; }

        public EFExamples2Context() : base("EFExamples2Context")
        {

            this.Configuration.LazyLoadingEnabled = true;

            // логгируем все обращения к базе данных в консоль для того что-б видеть когда и какие запросы посылаются
            //this.Database.Log = (s => Console.WriteLine(s));

            // указываем что база данных должна быть пересоздана каждый раз при изменении схемы
            // существуют также CreateDatabaseIfNotExists и DropCreateDatabaseAlways описанные по ссылке
            // https://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFExamples2Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new PrecisionAttributeConvention());


            modelBuilder.Entity<Parcel>().HasOptional(x => x.Werehouse).WithMany(x => x.Parcels);
            //modelBuilder.Conventions.Add(new IncludePrivatesConvention());


            //modelBuilder.Configurations.Add(new Parcel.ParcelConfiguration());

            // for rows below are required in order to change TPH inheritance strategy to TPT
            /*modelBuilder.Entity<CreateActivity>().ToTable("CreateActivitys");
            modelBuilder.Entity<ReadyForSendActivity>().ToTable("ReadyForSendActivitys");
            modelBuilder.Entity<RetrieveActivity>().ToTable("RetrieveActivitys");
            modelBuilder.Entity<SendActivity>().ToTable("SendActivitys");*/
        }
    }
}
