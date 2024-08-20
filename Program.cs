using Azure.Identity;
using DevUpConference.ApiTriggers;
using DevUpConference.Configuration;
using DevUpConference.Database;
using DevUpConference.QueueTriggers;
using DevUpConference.TimerTriggers;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication((context, builder) =>
    {
        // Add the settings required for the function app to run

        // Default set of converters
        // Default JsonSerializerOptions for casing
        // Integrate with Azure Function Logging 
        // gRPC Support

        //builder.UseMiddleware<ApiKeyMiddleware>();

        //builder.UseMiddleware<CertificateValidationMiddleware>();
    })
    .ConfigureAppConfiguration((context, builder) =>
    {
        if (context.HostingEnvironment.IsDevelopment())
        {
            // Using user.secrets file requires a NuGet Package
            // Microsoft.Extensions.Configuration.UserSecrets
            builder.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
        }
        else
        {
            var kvname = Environment.GetEnvironmentVariable("KeyVaultName");
            
            // Adding Azure KeyVault needs NuGet Packages
            // Microsoft.Extensions.AspNetCore.Configuration.Secrets
            // Azure.Identity
            builder.AddAzureKeyVault(
                new Uri($"https://{kvname}.vault.azure.net/"),
                new DefaultAzureCredential());
        }

        // appsettings.Environment.json files
        builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        // For DI you are going to need a NuGet Package
        // Microsoft.Extensions.DependencyInjection

        var configuration = context.Configuration.GetDevUpConferenceConfiguration();

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDbContext<DevUpDbContext>(options =>
        {
            options.UseSqlServer(configuration.ConnectionStrings.AppDb);    
        });

        services.AddScoped<IApiService, ApiService>();
        services.AddScoped<ITimerService, TimerService>();
        services.AddScoped<IQueueService, QueueService>();
    })
    .Build();

host.Run();
