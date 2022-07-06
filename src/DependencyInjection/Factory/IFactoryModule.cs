using Jab;

namespace DependencyInjection.Factory;

[ServiceProviderModule]
[Transient(typeof(IFactory), typeof(Factory))]
[Transient(typeof(IFactory<>), typeof(Factory<>))]
[Transient(typeof(IFactory<,>), typeof(Factory<,>))]
[Transient(typeof(IFactory<,,>), typeof(Factory<,,>))]
[Transient(typeof(IFactory<,,,>), typeof(Factory<,,,>))]
[Transient(typeof(IFactory<,,,,>), typeof(Factory<,,,,>))]
[Transient(typeof(IFactory<,,,,,>), typeof(Factory<,,,,,>))]
internal interface IFactoryModule
{
}