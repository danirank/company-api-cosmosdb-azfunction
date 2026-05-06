using Company.Core.Interfaces;
using Company.Core.Services;
using Company.Domain.Interfaces;
using Company.Domain.Repositories;
using Company.Function.Extensions;
using Customer.Core.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddResendEmailService(builder.Configuration);
builder.Services.AddCosmosClient(builder.Configuration);
builder.Services.AddScoped<IOutboxRepo, OutboxRepo>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
