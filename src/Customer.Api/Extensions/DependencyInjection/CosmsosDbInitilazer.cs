using Microsoft.Azure.Cosmos;

namespace Customer.Api.Extensions.DependencyInjection;
public class CosmosDbInitializer
{
    private readonly CosmosClient _client;

    public CosmosDbInitializer(CosmosClient client)
    {
        _client = client;
    }

    public async Task InitializeAsync()
    {
        var databaseName = "CompanyDb";

        var database = await _client.CreateDatabaseIfNotExistsAsync(databaseName);

        await database.Database.CreateContainerIfNotExistsAsync(
            new ContainerProperties
            {
                Id = "Customers",
                PartitionKeyPath = "/id"
            });

        await database.Database.CreateContainerIfNotExistsAsync(
            new ContainerProperties
            {
                Id = "Salesmen",
                PartitionKeyPath = "/id"
            }); 

        // await database.Database.CreateContainerIfNotExistsAsync(
        //     new ContainerProperties
        //     {
        //         Id = "leases",
        //         PartitionKeyPath = "/id"
        //     });    
    }
}