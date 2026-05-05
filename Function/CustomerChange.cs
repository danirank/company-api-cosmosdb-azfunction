using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Company.Core.Interfaces;
using Company.Domain.Dto;
using Company.Domain.Entities;
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
        containerName: "Customers",
        Connection = "CosmosDBConnection",
        LeaseContainerName = "leases",
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<CustomerEntity> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);

            foreach (var customer in input)
            {
                if (customer.EmailSetToSalesman || string.IsNullOrEmpty(customer.SalesmanEmail))
                    continue;
                
                _logger.LogInformation($"Customer ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
                var emailBuilder = new EmailBuilderDto
                {
                    ToEmail = customer.SalesmanEmail ?? string.Empty,
                    CustomerName = customer.Name,
                    CustomerEmail = customer.Email,
                    CustomerPhone = customer.Phone
                };

                _emailService.SendEmailAsync(emailBuilder).GetAwaiter().GetResult();

                customer.EmailSetToSalesman = true;

                _logger.LogInformation($"Customer ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");

                await container
            }



        }
    }
}

