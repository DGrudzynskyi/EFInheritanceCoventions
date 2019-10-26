using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class CreateActivity : Activity
    {
        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        public decimal ExpectedDeliveryFee { get; set; }

        public Werehouse TargetWerehouse { get; set; }
    }
}
