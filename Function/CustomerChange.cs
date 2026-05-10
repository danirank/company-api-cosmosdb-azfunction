using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Company.Core.Interfaces;
using Company.Domain.Dto;
using Company.Domain.Entities;
using Company.Domain.Interfaces;
namespace Function;

public class CustomerChange
{
    private readonly ILogger<CustomerChange> _logger;
    private readonly IEmailService _emailService;
    private readonly IOutboxRepo _outboxRepo;

    public CustomerChange(ILogger<CustomerChange> logger, IEmailService emailService, IOutboxRepo outboxRepo)
    {
        _logger = logger;
        _emailService = emailService;
        _outboxRepo = outboxRepo;
    }

    [Function("CustomerChange")]
    public async Task Run([CosmosDBTrigger(
        databaseName: "CompanyDb",
        containerName: "Outbox",
        Connection = "CosmosDBConnection",
        LeaseContainerName = "leases",
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<CustomerEntity> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);

            foreach (var item in input)
            {
                try
                {
                    await _emailService.SendEmailAsync(item.Status, item);

                    await _outboxRepo.DeleteOutboxAsync(item.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "Failed to process outbox item {Id}",
                        item.Id);
                }
            }
        }
    }
}

