using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.CustomConvention
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PrecisionAttribute : Attribute
    {
        public PrecisionAttribute(byte precision, byte scale)
        {
            Precision = precision;
            Scale = scale;
        }

        public byte Precision { get; set; }
        public byte Scale { get; set; }

    }
}
