using BSynchro.Contracts.Transactions.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BSynchro.Contracts.Transactions
{
    public interface ITransactionService
    {
        Task<IActionResult> Create(TransactionCreateDto input);
    }
}
