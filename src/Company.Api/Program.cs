using Azure.Identity;
using Company.Api.Endpoints;
using Company.Api.Extensions.DependencyInjection;
using Company.Core.Configurations;
using Company.Core.Interfaces;
using Company.Core.Services;
using Company.Domain.Interfaces;
using Company.Domain.Repositories;
using Customer.Core.Services;
using Resend;

namespace Company.Api;


public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddCosmosClient(builder.Configuration);
        builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<ISalesmanRepo, SalesmanRepo>();
        builder.Services.AddSingleton<CosmosDbInitializer>();
        builder.Services.AddScoped<IOutboxRepo, OutboxRepo>();

        builder.Services.AddTransient<IResend, ResendClient>();
        builder.Services.AddHttpClient<ResendClient>();
        builder.Services.AddOptions<ResendOptions>()
            .Bind(builder.Configuration
            .GetSection(ResendOptions.SectionName))
            .ValidateOnStart();

        builder.Services.Configure<ResendClientOptions>(
            builder.Configuration.GetSection("Resend")
        );

        builder.Services.AddScoped<IEmailService, EmailService>();
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

       // app.MapEmailEndpoints();
        app.MapCustomerEndpoints();



        app.Run();
    }
}
