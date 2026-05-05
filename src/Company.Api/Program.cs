using Azure.Identity;
using Company.Api.Endpoints;
using Company.Api.Extensions.DependencyInjection;
using Company.Core.Interfaces;
using Company.Domain.Interfaces;
using Company.Domain.Repositories;
using Customer.Core.Services;

namespace Company.Api;


public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddCosmosClient(builder.Configuration);
        builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddSingleton<CosmosDbInitializer>();

        builder.Services.AddOpenApi();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<CosmosDbInitializer>();
            await initializer.InitializeAsync();
        }
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }


        app.MapCustomerEndpoints();



        app.Run();
    }
}
