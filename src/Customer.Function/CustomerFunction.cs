using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CustomerFunction;

public class CustomerFunction
{
    private readonly ILogger<CustomerFunction> _logger;

    public CustomerFunction(ILogger<CustomerFunction> logger)
    {
        _logger = logger;
    }

    [Function("CustomerFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}