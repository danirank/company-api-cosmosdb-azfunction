using Customer.Domain.Entities;
namespace Customer.Domain.Interfaces;

public interface ICustomerRepo
{
    Task<CustomerEntity> AddCustomerAsync(CustomerEntity customer);
    Task<List<CustomerEntity>> GetCustomersAsync();
}