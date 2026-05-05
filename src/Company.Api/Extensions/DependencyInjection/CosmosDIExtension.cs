using Microsoft.Azure.Cosmos;

namespace Company.Api.Extensions.DependencyInjection;

public static class CosmosDIExtension
{
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
