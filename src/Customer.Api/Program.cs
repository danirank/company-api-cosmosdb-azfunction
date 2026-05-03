using Azure.Identity;
using Customer.Core.Interfaces;
using Customer.Core.Services;

namespace Customer.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var keyVaultUrl = builder.Configuration["KeyVault:Url"];
        if (!string.IsNullOrEmpty(keyVaultUrl))
        {
            builder.Configuration.AddAzureKeyVault(
            new Uri(keyVaultUrl),
            new DefaultAzureCredential());
        }

        builder.Services.AddScoped<ICustomerService, CustomerService>();
        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.Run();
    }
}
