using Microsoft.Azure.Cosmos;
using Company.Domain.Entities;
using Company.Domain.Interfaces;
using Microsoft.Azure.Cosmos.Linq;
using Company.Domain.Enums;

namespace Company.Domain.Repositories;

public class CustomerRepo : ICustomerRepo
{

    private readonly Container _container;

    public CustomerRepo(CosmosClient cosmosClient)
    {
        _container = cosmosClient
                .GetDatabase("CompanyDb")
                .GetContainer("CompanyData");
    }
    public async Task<CustomerEntity> AddCustomerAsync(CustomerEntity customer)
    {
        await _container.CreateItemAsync(customer, new PartitionKey(customer.Id));
        return customer;
    }

    public async Task<List<CustomerEntity>> GetCustomersAsync()
    {
        var query = new QueryDefinition("SELECT * FROM c WHERE c.type = @type")
            .WithParameter("@type", EntityType.Customer.ToString());

        using var iterator = _container.GetItemQueryIterator<CustomerEntity>(query);

        var customers = new List<CustomerEntity>();

        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            customers.AddRange(response);
        }

        return customers;
    }

    public async Task<CustomerEntity> GetCustomerByIdAsync(string customerId)
    {
        try
        {
            var response = await _container.ReadItemAsync<CustomerEntity>(customerId, new PartitionKey(customerId));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null!;
        }
    }

    public Task<CustomerEntity> UpdateCustomerAsync(CustomerEntity customer, string customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CustomerEntity>> GetCustomerByNameSearchAsync(string searchName)
    {
        var query = new QueryDefinition("SELECT * FROM c WHERE c.type = @type AND CONTAINS(c.name, @searchName)")
            .WithParameter("@type", EntityType.Customer.ToString())
            .WithParameter("@searchName", searchName);

        using var iterator =  _container.GetItemQueryIterator<CustomerEntity>(query);

        var customers = new List<CustomerEntity>();
        while (iterator.HasMoreResults)
        {
            var response = iterator.ReadNextAsync().Result;
            customers.AddRange(response);
        }

        return customers;
    }

    public async Task<List<CustomerEntity>> GetCustomersBySalesmanEmailAsync(string salesmanEmail)
    {
        var query = new QueryDefinition("SELECT * FROM c WHERE c.type = @type AND c.salesmanEmail = @salesmanEmail")
            .WithParameter("@type", EntityType.Customer.ToString())
            .WithParameter("@salesmanEmail", salesmanEmail);

        using var iterator = _container.GetItemQueryIterator<CustomerEntity>(query);

        var customers = new List<CustomerEntity>();
        while (iterator.HasMoreResults)
        {
            var response = iterator.ReadNextAsync().Result;
            customers.AddRange(response);
        }

        return customers;
    }
}
