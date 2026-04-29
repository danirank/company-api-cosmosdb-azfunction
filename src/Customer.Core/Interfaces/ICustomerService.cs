using Customer.Domain.Dto;

namespace Customer.Core.Interfaces; 

public interface ICustomerService
{
    Task<bool> AddCustomerAsync(AddCustomerDto customer);
    Task GetCustomersAsync();
}
