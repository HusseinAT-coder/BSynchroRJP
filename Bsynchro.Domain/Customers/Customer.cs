using Bsynchro.Domain.Acounts;
using BSynchro.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Domain.Customers
{
    public class Customer : IFullAuditEntity
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public decimal Balance { get; set; }

        public string Email { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}
