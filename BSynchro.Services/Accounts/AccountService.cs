using Bsynchro.Domain.Acounts;
using BSynchro.Contracts.Accounts;
using BSynchro.Contracts.Accounts.Dtos;
using BSynchro.Contracts.Transactions;
using BSynchro.Contracts.Transactions.Dtos;
using BSynchro.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.Services.Accounts
{
    public class AccountService : IAccountService
    {

        private readonly BSynchroDbContext _dbcontext;
        private readonly ITransactionService _transactionService;
        public AccountService(BSynchroDbContext dbcontext, ITransactionService transactionService)
        {
            _dbcontext = dbcontext;
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Create(AccountCreateInputDto input)
        {
            try
            {
                var customer = await _dbcontext.Customers.FirstOrDefaultAsync(customer => customer.Id == input.CustomerId);

                customer = customer ?? throw new ArgumentNullException(nameof(customer), "Customer not found");

                //create object account
                Account dbAccount = new Account
                {
                    CustomerId = input.CustomerId,
                };

                //save into db
                var result = await _dbcontext.Accounts.AddAsync(dbAccount);

                if (input.InitialCredit > 0)
                {
                    await _transactionService.Create(new TransactionCreateDto
                    {
                        AccountId = dbAccount.Id,
                        Amount = input.InitialCredit
                    });

                };

                await _dbcontext.SaveChangesAsync();

                return new OkObjectResult("Account created successfully");
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
