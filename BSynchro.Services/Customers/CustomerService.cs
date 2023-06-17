using BSynchro.Contracts.Customers;
using BSynchro.Contracts.Customers.Dtos;
using BSynchro.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly BSynchroDbContext _dbcontext;
        public CustomerService(BSynchroDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<CustomerListDto[]> FindAll()
        {
            var customers = await _dbcontext.Customers.Select(user => user).ToListAsync();

            if (customers.Count == 0)
            {
                throw new Exception("No customers found");
            }

            CustomerListDto[] result = new CustomerListDto[customers.Count];

            for (int i = 0; i < customers.Count; i++)
            {
                result[i] = new CustomerListDto
                {
                    Id = customers[i].Id,
                    Name = customers[i].Name,
                    SurName = customers[i].SurName,
                };
            }

            return result;
        }

        public async Task<CustomerDetailsDto> FindOne(Guid id)
        {
            var customer = await _dbcontext.Customers
                .Include(customer => customer.Accounts)
                    .ThenInclude(account => account.Transactions)
                .FirstOrDefaultAsync(customer => customer.Id == id);

            customer = customer ?? throw new ArgumentNullException(nameof(customer), "Customer not found");

            CustomerDetailsDto result = new CustomerDetailsDto(customer);

            return result;
        }
    }
}
