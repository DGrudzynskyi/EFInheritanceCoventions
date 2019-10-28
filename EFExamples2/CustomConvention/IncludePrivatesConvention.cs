using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.CustomConvention
{
    public class IncludePrivatesConvention : Convention
    {
        public IncludePrivatesConvention() {
            // берем все типы, известные EF (Зарегестрированные как DbSet)
            Types().Configure(type =>
            {
                // находим не-публичные свойства
                var nonPublicProperties = type.ClrType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

                // явно из декларируем
                foreach (var p in nonPublicProperties)
                {
                    if (!p.PropertyType.IsGenericType)
                    {
                        type.Property(p).HasColumnName(p.Name);
                    }
                }
            });
        }
    }
}
