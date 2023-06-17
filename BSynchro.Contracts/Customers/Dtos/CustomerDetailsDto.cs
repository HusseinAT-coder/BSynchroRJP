using Bsynchro.Domain.Acounts;
using Bsynchro.Domain.Customers;
using BSynchro.Contracts.Accounts.Dtos;
using BSynchro.Contracts.Transactions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Contracts.Customers.Dtos
{
    public class CustomerDetailsDto
    {

        public CustomerDetailsDto(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            SurName = customer.SurName;
            Email = customer.Email;
            Accounts = customer.Accounts != null
            ? customer.Accounts.Select(account => new AccountDetailsDto(account)).ToList()
            : new List<AccountDetailsDto>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public List<AccountDetailsDto> Accounts { get; set; }

    }
}
