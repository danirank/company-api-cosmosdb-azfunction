using Company.Core.Interfaces;
using Company.Domain.Dto;


namespace Company.Api.Endpoints;

public static class CustomerEndpoints
{
    public static WebApplication MapCustomerEndpoints(this WebApplication app)
    {

        var customerGroup = app.MapGroup("/api/customers");
        customerGroup.MapPost("/", CreateCustomer);
        customerGroup.MapGet("/search", GetCustomerByNameSearch);
        customerGroup.MapGet("/salesman", GetCustomersBySalesmanEmail);
        customerGroup.MapGet("/{id}", GetCustomerById);
        customerGroup.MapPut("/{id}", UpdateCustomer);
        customerGroup.MapGet("/", GetCustomers);
        
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

    public static async Task<IResult> GetCustomerById(ICustomerService customerService, string id)
    {
        var result = await customerService.GetCustomerByIdAsync(id);
        return Results.Ok(result);
    }

    public static async Task<IResult> UpdateCustomer(ICustomerService customerService, UpdateCustomerDto request, string id)
    {
        var result = await customerService.UpdateCustomerAsync(request, id);
        return Results.Ok(result);
    }

    public static async Task<IResult> GetCustomerByNameSearch(ICustomerService customerService, string name)
    {
        var result = await customerService.GetCustomerByNameSearchAsync(name);
        return Results.Ok(result);
    }

    public static async Task<IResult> GetCustomersBySalesmanEmail(
    ICustomerService customerService,
    string salesmanEmail)
    {
        var result = await customerService.GetCustomersBySalesmanEmailAsync(salesmanEmail);
        return Results.Ok(result);
    }

  
}