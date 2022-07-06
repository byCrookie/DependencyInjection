using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Microsoft.Modules;

public static class ModuleExtensions
{
    public static IServiceCollection UseModule(this IServiceCollection services, Module module)
    {
        module.Load(services);
        return services;
    }
}