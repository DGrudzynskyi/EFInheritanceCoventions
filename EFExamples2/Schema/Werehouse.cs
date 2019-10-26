using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public class Werehouse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public virtual List<Parcel> Parcels { get; set; }
    }
}
