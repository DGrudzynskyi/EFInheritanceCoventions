using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.CustomConvention
{
    public class PrecisionAttributeConvention
    : PrimitivePropertyAttributeConfigurationConvention<PrecisionAttribute>
    {
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, PrecisionAttribute attribute)
        {
            configuration.HasPrecision(attribute.Precision, attribute.Scale);
        }
    }
}
