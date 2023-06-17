using BSynchro.Contracts.Accounts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BSynchro.Contracts.Accounts
{
    public interface IAccountService
    {
        Task<IActionResult> Create(AccountCreateInputDto input);
    }
}
