using Company.Domain.Entities;
namespace Company.Domain.Interfaces;

public interface ICustomerRepo
{
    Task<CustomerEntity> AddCustomerAsync(CustomerEntity customer);
    Task<List<CustomerEntity>> GetCustomersAsync();
}