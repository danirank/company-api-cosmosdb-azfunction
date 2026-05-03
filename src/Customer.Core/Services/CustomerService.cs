using Customer.Core.Interfaces;
using Customer.Domain.Dto;

namespace Customer.Core.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerService _customerService;

    public CustomerService(ICustomerService customerService)
    {
        _customerService = customerService;
    }


    public Task<bool> AddCustomerAsync(AddCustomerDto customer)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetCustomersDto>> GetCustomersAsync()
    {
        throw new NotImplementedException();
    }
}