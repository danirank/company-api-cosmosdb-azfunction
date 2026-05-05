using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Function;

public class CustomerChange
{
    private readonly ILogger<CustomerChange> _logger;

    public CustomerChange(ILogger<CustomerChange> logger)
    {
        _logger = logger;
    }

    [Function("CustomerChange")]
    public void Run([CosmosDBTrigger(
        databaseName: "CompanyDb",
        containerName: "Customers",
        Connection = "CosmosDBConnection",
        LeaseContainerName = "leases",
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<dynamic> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);
        }
    }
}

