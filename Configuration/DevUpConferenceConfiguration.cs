using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevUpConference.Configuration;

public class AzureStorageConfiguration
{
    public string ConnectionString { get; set; } = default!;
    public string ContainerName { get; set; } = default!;
}

public class ConnectionStringsConfiguration
{
    public string AppDb { get; set; } = default!;
}

public class KeyVaultConfiguration
{
    public string KeyVaultName { get; set; } = default!;
}

public class DevUpConferenceConfiguration
{
    public AzureStorageConfiguration AzureStorage { get; set; } = default!;
    public ConnectionStringsConfiguration ConnectionStrings { get; set; } = default!;
    public KeyVaultConfiguration KeyVault { get; set; } = default!;

    public DevUpConferenceConfiguration()
    {
        AzureStorage = new();

        ConnectionStrings = new();

        KeyVault = new();
    }
}

public static class ConfigurationExtensions
{
    public static DevUpConferenceConfiguration GetDevUpConferenceConfiguration(this IConfiguration configuration)
    {
        var devup = new DevUpConferenceConfiguration();

        configuration.GetSection("AzureStorage").Bind(devup.AzureStorage);

        configuration.GetSection("ConnectionStrings").Bind(devup.ConnectionStrings);

        devup.KeyVault.KeyVaultName = configuration.GetValue<string>("KeyVaultName");

        return devup;
    }

    public static IServiceCollection AddDevUpConferenceConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var devup = configuration.GetDevUpConferenceConfiguration();

        services.AddSingleton(devup);

        services.AddSingleton(devup.AzureStorage);

        return services;
    }
}