using BSynchro.Contracts.Customers.Dtos;

namespace BSynchro.Contracts.Customers
{
    public interface ICustomerService
    {
        Task<CustomerListDto[]> FindAll();

        Task<CustomerDetailsDto> FindOne(Guid id);
    }
}
