using Bsynchro.Domain.Transactions;

namespace BSynchro.Contracts.Transactions.Dtos
{
    public class TransactionDetailsDto
    {
        public TransactionDetailsDto(Transaction transaction)
        {
            Id = transaction.Id;
            Amount = transaction.Amount;
        }
        public Guid Id { get; set; }

        public decimal Amount { get; set; }
    }
}
