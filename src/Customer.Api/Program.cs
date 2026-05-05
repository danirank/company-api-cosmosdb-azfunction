using Azure.Identity;
using Customer.Api.Endpoints;
using Customer.Api.Extensions.DependencyInjection;
using Customer.Core.Interfaces;
using Customer.Core.Services;
using Customer.Domain.Interfaces;
using Customer.Domain.Repositories;
using Microsoft.Azure.Cosmos;
namespace Customer.Api;


public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // var keyVaultUrl = builder.Configuration["KeyVault:Url"];
        // if (!string.IsNullOrEmpty(keyVaultUrl))
        // {
        //     builder.Configuration.AddAzureKeyVault(
        //     new Uri(keyVaultUrl),
        //     new DefaultAzureCredential());
        // }


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
