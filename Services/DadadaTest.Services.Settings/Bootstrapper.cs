namespace DadataTest.Services.Settings;

using DadataTest.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<MainSettings>("Main", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddLogSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<LogSettings>("Log", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddDadataSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<DadataSettings>("Dadata", configuration);
        services.AddSingleton(settings);

        return services;
    }

}