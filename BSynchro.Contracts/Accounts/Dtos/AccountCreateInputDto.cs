using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Contracts.Accounts.Dtos
{
    public class AccountCreateInputDto
    {
        public Guid CustomerId { get; set; }

        public decimal InitialCredit { get; set; }
    }
}
