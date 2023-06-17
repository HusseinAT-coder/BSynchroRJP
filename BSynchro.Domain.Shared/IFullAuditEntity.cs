using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Domain.Shared
{
    public class IFullAuditEntity : IAuditEntity
    {
        public DateTime? LastUpdateDate { get; set; }
    }
}
