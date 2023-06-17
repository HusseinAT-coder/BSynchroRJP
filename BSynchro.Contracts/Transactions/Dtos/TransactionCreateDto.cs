using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Contracts.Transactions.Dtos
{
    public class TransactionCreateDto
    {
        public Guid AccountId { get; set; }

        public decimal Amount { get; set; }
    }
}
