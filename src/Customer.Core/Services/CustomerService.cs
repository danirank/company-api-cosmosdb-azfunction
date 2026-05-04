using Customer.Core.Interfaces;
using Customer.Domain.Dto;
using Customer.Domain.Entities;
using Customer.Domain.Interfaces;

namespace Customer.Core.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepo _repo;

    public CustomerService(ICustomerRepo repo)
    {
        _repo = repo;
    }


    public async Task<GetCustomerDto> AddCustomerAsync(AddCustomerDto customer)
    {
        if (customer is null)
            return new GetCustomerDto { ErrorMessage = "Customer data is null." };

        var customerEntity = new CustomerEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = customer.Name,
            Title = customer.Title,
            Address = customer.Address,
            Phone = customer.Phone,
            Email = customer.Email,
            SalesmanId = customer.SalesmanId
        };

        if (string.IsNullOrEmpty(customerEntity.Id))
            return new GetCustomerDto { ErrorMessage = "Failed to generate customer ID." };

        var result = await _repo.AddCustomerAsync(customerEntity);

        if (result is null)
            return new GetCustomerDto { ErrorMessage = "Failed to add customer." };

        return new GetCustomerDto
        {
            Id = result.Id,
            Name = result.Name,
            Title = result.Title,
            Address = result.Address,
            Phone = result.Phone,
            Email = result.Email,
            SalesmanId = result.SalesmanId
        };


    }

    public async Task<List<GetCustomersDto>> GetCustomersAsync()
    {
        var customers = await _repo.GetCustomersAsync();

        return customers.Select(c => new GetCustomersDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email
        }).ToList();
    }
}