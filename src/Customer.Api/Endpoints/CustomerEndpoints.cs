using Customer.Core.Interfaces;
using Customer.Domain.Dto;

namespace Customer.Api.Endpoints;

public static class CustomerEndpoints
{
    public static WebApplication MapCustomerEndpoints(this WebApplication app)
    {
        app.MapPost("/customer", async (
            ICustomerService customerService,
            AddCustomerDto customer) 
            => {
                var result =  await customerService.AddCustomerAsync(customer);
            });

        return app;
    }
}