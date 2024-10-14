using Microsoft.Extensions.DependencyInjection;

namespace DadataTest.AdressService;

public static class Bootstrapper
{
    public static IServiceCollection addAdresService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IAdressService, AdressService>();
    }

}
