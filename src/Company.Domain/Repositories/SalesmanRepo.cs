namespace Company.Domain.Repositories;

using Company.Domain.Entities;
using Company.Domain.Enums;
using Company.Domain.Interfaces;
using Microsoft.Azure.Cosmos;

public class SalesmanRepo : ISalesmanRepo
{
    private readonly Container _container;

    public SalesmanRepo(CosmosClient cosmosClient)
    {
        _container = cosmosClient
                .GetDatabase("CompanyDb")
                .GetContainer("CompanyData");
    }
    public async Task<Salesman> AddSalesmanAsync(Salesman salesman)
    {
        await _container.CreateItemAsync(salesman, new PartitionKey(salesman.Type.ToString()));
        return salesman;
    }

    public async Task<Salesman?> GetSalesmanByEmailAsync(string email)
    {
        var query = new QueryDefinition(
            "SELECT * FROM c" +
            "WHERE c.email = @email")
            .WithParameter("@email", email)
            .WithParameter("@type", EntityType.Salesman.ToString());

        using var iterator = _container.GetItemQueryIterator<Salesman>(query);

        var salesman = await iterator.ReadNextAsync();

        if (salesman.Count() == 0)
        {
            return null!;
        }
        return  salesman.FirstOrDefault();

        

    }

    public async Task<Salesman> GetSalesmanByIdAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<Salesman>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null!;
        }
    }
    public async Task<List<Salesman>> GetSalesmenAsync()
    {
        var query = new QueryDefinition(
            "SELECT * FROM c" +
            "WHERE c.type = @type")
            .WithParameter("@type", EntityType.Salesman.ToString());

        using var iterator = _container.GetItemQueryIterator<Salesman>(query);

        var salesmen = new List<Salesman>();

        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            salesmen.AddRange(response);
        }

        return salesmen;
    }
}