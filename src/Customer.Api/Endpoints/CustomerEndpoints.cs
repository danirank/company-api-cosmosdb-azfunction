using Customer.Core.Interfaces;
using Customer.Domain.Dto;

namespace Customer.Api.Endpoints;

public static class CustomerEndpoints
{
    public static WebApplication MapCustomerEndpoints(this WebApplication app)
    {

        var customerGroup = app.MapGroup("/api/customers");
        customerGroup.MapPost("/", CreateCustomer);

        return app;
    }

    public static async Task<IResult> CreateCustomer(ICustomerService customerService, AddCustomerDto request)
    {
        var result = await customerService.AddCustomerAsync(request);
        return Results.Ok(result);
    }

    public static async Task<IResult> GetCustomers(ICustomerService customerService)
    {
        var result = await customerService.GetCustomersAsync();
        return Results.Ok(result);
    }
}