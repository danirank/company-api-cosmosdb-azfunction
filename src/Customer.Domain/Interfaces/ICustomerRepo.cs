using Customer.Domain.Entities;
namespace Customer.Domain.Interfaces;

public interface ICustomerRepo
{
    Task<bool> AddCustomerAsync(CustomerEntity customer);
}