using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Domain.Shared
{
    public class IAuditEntity : IEntity
    {
        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletionDate { get; set; }


    }
}
