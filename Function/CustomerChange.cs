using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Company.Core.Interfaces;
using Company.Domain.Interfaces;
using Company.Domain.Enums;

namespace Function;

public class CustomerChange
{
    private readonly ILogger<CustomerChange> _logger;
    private readonly IEmailService _emailService;

    public CustomerChange(ILogger<CustomerChange> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }

    [Function("CustomerChange")]
    public async Task Run([CosmosDBTrigger(
        databaseName: "CompanyDb",
        containerName: "CompanyData",
        Connection = "CosmosDBConnection",
        LeaseContainerName = "leases",
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<dynamic> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);

            foreach (var item in input)
            {
                if (item.Type == EntityType.Salesman)
                    continue;

                try
                {
                     
                    await _emailService.SendEmailAsync(item.Status, item);

                   
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message,
                        "Failed to process outbox item {Id}");
                }
            }
        }
    }
}

