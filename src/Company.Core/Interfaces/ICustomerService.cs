using Company.Domain.Dto;
    
namespace Company.Core.Interfaces;

public interface ICustomerService
{
    Task<GetCustomerDto> AddCustomerAsync(AddCustomerDto customer);
    Task<List<GetCustomersDto>> GetCustomersAsync();
    Task<GetCustomerDto> GetCustomerByIdAsync(string customerId);

    Task<List<GetCustomersDto>> GetCustomerByNameSearchAsync(string searchName);

    Task<List<GetCustomersDto>> GetCustomersBySalesmanEmailAsync(string salesmanEmail);

    Task<GetCustomerDto> UpdateCustomerAsync(UpdateCustomerDto customer, string customerId);

}
