using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2
{
    class Program
    {
        static void Main(string[] args)
        {
            // DeliveryStepsBold.RetreivedByCustoms();
            // DeliveryStepsBold.ProcessedAndSentByCustoms();

            DeliverySteps.RetreivedByCustoms();
            DeliverySteps.ProcessedAndSentByCustoms();


            DeliverySteps.RevertLastActivity();

            Console.ReadKey();
        }
    }
}
