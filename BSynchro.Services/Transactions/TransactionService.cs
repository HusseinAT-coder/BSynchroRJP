using Bsynchro.Domain.Transactions;
using BSynchro.Contracts.Accounts.Dtos;
using BSynchro.Contracts.Customers.Dtos;
using BSynchro.Contracts.Transactions;
using BSynchro.Contracts.Transactions.Dtos;
using BSynchro.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly BSynchroDbContext _dbcontext;
        public TransactionService(BSynchroDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IActionResult> Create(TransactionCreateDto input)
        {
            var transaction = new Transaction
            {
                AccountId = input.AccountId,
                Amount = input.Amount,
            };

            await _dbcontext.Transactions.AddAsync(transaction);

            return new OkObjectResult("Transaction created successfully");
        }
    }
}
