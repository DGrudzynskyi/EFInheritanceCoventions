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
            var deliveryService = new DeliveryService();
            deliveryService.RetreivedByCustoms();
            deliveryService.ProcessedAndSentByCustoms();

            Console.ReadKey();
        }
    }
}
