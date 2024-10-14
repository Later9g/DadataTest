using DadataTest.AdressService;
using DadataTest.Services.Logger;
using DadataTest.Services.Settings;

namespace DadataTest.Api;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddLogSettings()
            .AddDadataSettings()
            .AddHttpClient()
            .addAdresService();
        
        return services;
    }
}
