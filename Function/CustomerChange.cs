using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Company.Core.Interfaces;
using Company.Domain.Interfaces;
using Company.Domain.Enums;
using System.Text.Json;
using Company.Domain.Entities;
using System.Text.Json.Serialization;

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
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<JsonElement> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);

            foreach (var item in input)
            {
                var type = item.GetProperty("type").GetString();

                switch (type)
                {
                    case "Customer":
                    {
                        var customer = item.Deserialize<CustomerEntity>(
                            new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true,
                                Converters =
                                {
                                    new JsonStringEnumConverter()
                                }
                            });

                        if (customer is null)
                            continue;
                        _logger.LogInformation("Customer: " + customer.Name + " - " + customer.Status.ToString());
                        await _emailService.SendEmailAsync(
                            customer.Status,
                            customer);

                        break;
                    }

                    case "Salesman":
                    {
                        var salesman = item.Deserialize<Salesman>();

                        if (salesman is null)
                            continue;

                        break;
                    }
                }
            }
        }
    }
}

