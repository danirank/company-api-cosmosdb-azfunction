using Microsoft.Azure.Cosmos;
using Customer.Domain.Entities;
using Customer.Domain.Interfaces;
using Microsoft.Azure.Cosmos.Linq;

namespace Customer.Domain.Repositories;

public class CustomerRepo : ICustomerRepo
{

    private readonly Container _container;

    public CustomerRepo(CosmosClient cosmosClient)
    {
        _container = cosmosClient
                .GetDatabase("CompanyDb")
                .GetContainer("Customers");
    }
    public async Task<CustomerEntity> AddCustomerAsync(CustomerEntity customer)
    {
        await _container.CreateItemAsync(customer, new PartitionKey(customer.Id));
        return customer;
    }

    public async Task<List<CustomerEntity>> GetCustomersAsync()
    {
        var query = new QueryDefinition("SELECT * FROM c");

        using var iterator = _container.GetItemQueryIterator<CustomerEntity>(query);

        var customers = new List<CustomerEntity>();

        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            customers.AddRange(response);
        }

        return customers;
    }
}
