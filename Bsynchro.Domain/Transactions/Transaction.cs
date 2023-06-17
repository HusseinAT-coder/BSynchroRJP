using Bsynchro.Domain.Acounts;
using Bsynchro.Domain.Customers;
using BSynchro.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Domain.Transactions
{
    public class Transaction : IAuditEntity
    {
        public decimal Amount { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }
    }
}
