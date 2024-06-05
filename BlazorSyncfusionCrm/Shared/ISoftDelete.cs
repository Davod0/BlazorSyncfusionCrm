using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSyncfusionCrm.Shared
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DateDeleted { get; set; }
    }
}
