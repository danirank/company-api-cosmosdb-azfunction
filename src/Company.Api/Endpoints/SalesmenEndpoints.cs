using Company.Core.Interfaces;
using Company.Core.Services;
using Company.Domain.Dto;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Company.Api.Endpoints;

public static class SalesmanEndpoints
{
    public static WebApplication MapSalesmanEndpoints(this WebApplication app)
    {

        var customerGroup = app.MapGroup("/api/salesmen");
        customerGroup.MapPost("/", CreateSalesman);
        customerGroup.MapGet("/", GetSalesmen);
        customerGroup.MapGet("/email", GetSalesmanByEmail); 
        
        return app;
    }

    public static async Task<IResult> CreateSalesman(ISalesmenService salesmanService, AddSalesmanDto request)
    {
        var result = await salesmanService.AddSalesmanAsync(request);
        return Results.Ok(result);
    }

    public static async Task<IResult> GetSalesmen(ISalesmenService salesmanService)
    {
        var result = await salesmanService.GetSalesmenAsync();
        return Results.Ok(result);
    }

    public static async Task<IResult> GetSalesmanByEmail(ISalesmenService salesmanService, string email)
    {
        var result = await salesmanService.GetSalesmanByEmailAsync(email);
        return Results.Ok(result);
    } 
  
}