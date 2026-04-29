using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Configuration;
using Azure.Identity;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = FunctionsApplication.CreateBuilder(args);

        builder.ConfigureFunctionsWebApplication();

       var keyVaultUrl = builder.Configuration["KeyVault:Url"];
       if (!string.IsNullOrEmpty(keyVaultUrl))
        {
                builder.Configuration.AddAzureKeyVault(
                new Uri(keyVaultUrl),
                new DefaultAzureCredential());
        }

        builder.Services
            .AddApplicationInsightsTelemetryWorkerService()
            .ConfigureFunctionsApplicationInsights();

        builder.Build().Run();
    }
}