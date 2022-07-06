using DependencyInjection.Factory;
using Jab;

namespace DependencyInjection;

[ServiceProviderModule]
[Import(typeof(IFactoryModule))]
public interface IDependencyInjectionModule
{
    
}