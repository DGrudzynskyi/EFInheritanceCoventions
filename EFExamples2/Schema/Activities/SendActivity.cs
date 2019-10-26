using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class SendActivity : Activity
    {
        public decimal? AdditionaldDeliveryFee { get; set; }

        public Werehouse SentToWerehouse { get; set; }
    }
}
