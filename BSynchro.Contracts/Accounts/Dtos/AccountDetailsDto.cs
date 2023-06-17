using Bsynchro.Domain.Acounts;
using Bsynchro.Domain.Customers;
using BSynchro.Contracts.Transactions.Dtos;

namespace BSynchro.Contracts.Accounts.Dtos
{
    public class AccountDetailsDto
    {
        public AccountDetailsDto(Account account)
        {
            Id = account.Id;
            Transactions = account.Transactions != null
            ? account.Transactions.Select(transaction => new TransactionDetailsDto(transaction)).ToList()
            : new List<TransactionDetailsDto>();
        }

        public Guid Id { get; set; }
        public List<TransactionDetailsDto> Transactions { get; set; }
    }
}
