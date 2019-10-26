using EFExamples2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.ActivityHandlers
{
    public interface IActivityHandler
    {
        Parcel Apply(Parcel toParcel, Activity activity);

        Parcel Revert(Activity activity);
    }
}
