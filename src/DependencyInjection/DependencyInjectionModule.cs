using DependencyInjection.Factory;
using DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection;

public class DependencyInjectionModule : Module
{
    public override void Load(IServiceCollection services)
    {
        AddModule(new FactoryModule());
        
        base.Load(services);
    }
}