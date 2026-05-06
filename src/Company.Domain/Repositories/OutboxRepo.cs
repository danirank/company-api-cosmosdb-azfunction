
using Company.Domain.Dto;
using Company.Domain.Interfaces;
using Microsoft.Azure.Cosmos;
namespace Company.Domain.Repositories;

public class OutboxRepo : IOutboxRepo
{
    private readonly Container _container;

    public OutboxRepo(CosmosClient client)
    {
        _container = client.GetContainer("CompanyDb", "Outbox");
    }

    public async Task AddOutboxAsync(OutboxDto outbox)
    {
        await _container.CreateItemAsync(outbox, new PartitionKey(outbox.Id));

    }

    public Task DeleteOutboxAsync(string outboxId)
    {
        return _container.DeleteItemAsync<OutboxDto>(outboxId, new PartitionKey(outboxId));
    }
}