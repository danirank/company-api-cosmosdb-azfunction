using Company.Domain.Entities;
namespace Company.Domain.Interfaces;

public interface ICustomerRepo
{
    Task<CustomerEntity> AddCustomerAsync(CustomerEntity customer);
    Task<List<CustomerEntity>> GetCustomersAsync();
    Task<CustomerEntity> GetCustomerByIdAsync(string customerId);

    Task<CustomerEntity> UpdateCustomerAsync(CustomerEntity customer, string customerId);

    Task<List<CustomerEntity>> GetCustomerByNameSearchAsync(string searchName);
    Task <List<CustomerEntity>> GetCustomersBySalesmanEmailAsync(string salesmanEmail);

}