using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Microsoft.Modules;

public abstract class Module
{
    private readonly List<Module> _modules;

    protected Module()
    {
        _modules = new List<Module>();
    }

    public virtual void Load(IServiceCollection services)
    {
        foreach (var module in _modules)
        {
            module.Load(services);
        }
    }

    protected void AddModule(Module module)
    {
        _modules.Add(module);
    }
}