
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

        public DbSet<Activity> Activities { get; set; }

        public EFExamples2Context() : base("EFExamples2Context")
        {

            this.Configuration.LazyLoadingEnabled = true;

            // логгируем все обращения к базе данных в консоль для того что-б видеть когда и какие запросы посылаются
            // this.Database.Log = (s => Console.WriteLine(s));

            // указываем что база данных должна быть пересоздана каждый раз при изменении схемы
            // существуют также CreateDatabaseIfNotExists и DropCreateDatabaseAlways описанные по ссылке
            // https://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFExamples2Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new PrecisionAttributeConvention());
            modelBuilder.Conventions.Add(new IncludePrivatesConvention());
        }
    }
}
