using Company.Core.Configurations;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resend;

namespace Company.Function.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddResendEmailService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IResend, ResendClient>();
        services.AddHttpClient<ResendClient>();
        services.AddOptions<ResendOptions>()
            .Bind(configuration
            .GetSection(ResendOptions.SectionName))
            .ValidateOnStart();

        services.Configure<ResendClientOptions>(
            configuration.GetSection("Resend")
        );

        return services;
    }

    public static IServiceCollection AddCosmosClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();

            return new CosmosClient(
                config["CosmosDb:AccountEndpoint"],
                config["CosmosDb:AuthKey"],
                new CosmosClientOptions
                {
                    ConnectionMode = ConnectionMode.Gateway,
                    LimitToEndpoint = true,
                    RequestTimeout = TimeSpan.FromSeconds(10),
                    HttpClientFactory = () =>
                    {
                        var handler = new HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback =
                                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                        };

                        return new HttpClient(handler);
                    }
                });
        });

        return services;
    }

    
}