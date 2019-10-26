using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.Schema
{
    public abstract class Activity
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual Parcel Parcel { get; set; }

        public virtual Werehouse Werehouse { get; set; }

        public bool IsReverted { get; set; }
    }
}
