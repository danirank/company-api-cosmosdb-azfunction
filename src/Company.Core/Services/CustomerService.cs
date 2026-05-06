using Company.Core.Interfaces;
using Company.Domain.Dto;
using Company.Domain.Entities;
using Company.Domain.Enums;
using Company.Domain.Interfaces;

namespace Customer.Core.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepo _repo;
    private readonly IOutboxRepo _outboxRepo;

    public CustomerService(ICustomerRepo repo, IOutboxRepo outboxRepo)
    {
        _repo = repo;
        _outboxRepo = outboxRepo;
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


        try
        {
            await _outboxRepo.AddOutboxAsync(new OutboxDto
            {
                Id = Guid.NewGuid().ToString(),
                EventType = OutboxType.Created,
                CustomerId = result.Id,
                CreatedAt = DateTime.UtcNow,

            });
        }
        catch
        {
            return new GetCustomerDto
            {
                ErrorMessage = "Customer was created, but notification could not be queued."
            };
        }

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