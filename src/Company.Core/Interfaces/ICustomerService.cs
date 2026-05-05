using Company.Domain.Dto;
    
namespace Company.Core.Interfaces;

public interface ICustomerService
{
    Task<GetCustomerDto> AddCustomerAsync(AddCustomerDto customer);
    Task<List<GetCustomersDto>> GetCustomersAsync();
}
