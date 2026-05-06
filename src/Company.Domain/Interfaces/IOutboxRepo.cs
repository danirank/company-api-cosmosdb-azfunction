using Company.Domain.Dto;

namespace Company.Domain.Interfaces;

public interface IOutboxRepo
{
    Task AddOutboxAsync(OutboxDto outbox);

    Task DeleteOutboxAsync(string outboxId);
}