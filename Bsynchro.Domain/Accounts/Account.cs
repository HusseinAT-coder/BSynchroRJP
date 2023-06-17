using Bsynchro.Domain.Customers;
using Bsynchro.Domain.Transactions;
using BSynchro.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Domain.Acounts
{
    public class Account : IFullAuditEntity
    {
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}
