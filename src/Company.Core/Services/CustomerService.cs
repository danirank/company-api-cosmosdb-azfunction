using Company.Core.Interfaces;
using Company.Domain.Dto;
using Company.Domain.Entities;
using Company.Domain.Enums;
using Company.Domain.Interfaces;

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
            SalesmanEmail = customer.SalesmanEmail
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
            SalesmanEmail = result.SalesmanEmail
        };


    }

    public async Task<GetCustomerDto> GetCustomerByIdAsync(string customerId)
    {
        var customer = await _repo.GetCustomerByIdAsync(customerId);
        if (customer is null)
            return new GetCustomerDto { ErrorMessage = $"Customer with ID {customerId} not found." };

        return new GetCustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Title = customer.Title,
            Address = customer.Address,
            Phone = customer.Phone,
            Email = customer.Email,
            SalesmanEmail = customer.SalesmanEmail
        };

    }

    public async Task<List<GetCustomersDto>> GetCustomerByNameSearchAsync(string searchName)
    {
        var customers = await _repo.GetCustomerByNameSearchAsync(searchName);

        return customers.Select(c => new GetCustomersDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email

        }).ToList();
        
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

    public async Task<List<GetCustomersDto>> GetCustomersBySalesmanEmailAsync(string salesmanEmail)
    {
        var customers = await _repo.GetCustomerByNameSearchAsync(salesmanEmail);

        return customers.Select(c => new GetCustomersDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email
            
        }).ToList();
    }

    public async Task<GetCustomerDto> UpdateCustomerAsync(UpdateCustomerDto customer, string customerId)
    {
        var customerToUpdate = await _repo.GetCustomerByIdAsync(customerId);
        if (customerToUpdate is null)
            return new GetCustomerDto { ErrorMessage = $"Customer with ID {customerId} not found." };
            

        customerToUpdate.Name = customer.Name ?? customerToUpdate.Name;
        customerToUpdate.Status = customer.Status;
        customerToUpdate.Title = customer.Title ?? customerToUpdate.Title;
        customerToUpdate.Address = customer.Address ?? customerToUpdate.Address;
        customerToUpdate.Phone = customer.Phone ?? customerToUpdate.Phone;
        customerToUpdate.Email = customer.Email ?? customerToUpdate.Email;
        customerToUpdate.SalesmanEmail = customer.SalesmanEmail ?? customerToUpdate.SalesmanEmail;

        var result = await _repo.UpdateCustomerAsync(customerToUpdate);

        if (result is null)
            return new GetCustomerDto { ErrorMessage = "Failed to update customer." };


        return new GetCustomerDto
        {
            Id = result.Id,
            Name = result.Name,
            Title = result.Title,
            Address = result.Address,
            Phone = result.Phone,
            Email = result.Email,
            SalesmanEmail = result.SalesmanEmail
        };

    }
}