using Customer.Domain.Dto;

namespace Customer.Core.Interfaces;

public interface ICustomerService
{
    Task<GetCustomerDto> AddCustomerAsync(AddCustomerDto customer);
    Task<List<GetCustomersDto>> GetCustomersAsync();
}
