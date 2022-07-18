# DependencyInjection
A microsoft dependency-injection extension providing support for modules.

## Dependencies & Acknowledgements
This project relies on following packages:
* BuildSdk: https://github.com/byCrookie/BuildSdk

## How to use

### Local Nuget Source
* Download the nuget package
* Add download path as nuget source
* Reference the package in your project

### Remote Nuget-Source

Add remote nuget source to your nuget.config:

* {Token}: Z2hwX1hybmFLaVIyTm1zaGVWRVpqMjVLbHZsNTBjdldKYjMzQ2hPeQ== -> Convert Base64 back to Text First
* Execute: dotnet nuget add source --username byCrookie --password {Token} --name byCrookie_Github --store-password-in-clear-text https://nuget.pkg.github.com/byCrookie/index.json

### Dev

* Clone the git repository
* Change the "localPackages" path in the nuget.config

## Contributing / Issues
All contributions are welcome! If you have any issues or feature requests, either implement it yourself or create an issue, thank you.

## Donation
If you like this project, feel free to donate and support further development. Thank you.

* Bitcoin (BTC) Donations using Bitcoin (BTC) Network -> bc1qygqya2w3hgpvy8hupctfkv5x06l69ydq4su2e2
* Ethereum (ETH) Donations using Ethereum (ETH) Network -> 0x1C0416cC1DDaAEEb3017D4b8Dcd3f0B82f4d94C1

## Docs

### Modules

Use modules like this adding services to the service collection.

```c#
public class WorkflowModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient(typeof(IWorkflowBuilder<>), typeof(WorkflowBuilder<>));
        
        AddModule(new DependencyInjectionModule());
        
        base.Load(services);
    }
}
```

To register the module dependency tree. Add it to the configuration or call the root module load method using the service collection.

```c#
public static IServiceCollection AddWorkflow(this IServiceCollection services)
{
    new WorkflowModule().Load(services);
    return services;
}
```

### Factory

To create instances on your own, you can inject IFactory into your services which uses IServiceProvider under the hood to respolve the component.

```c#
public WorkflowBuilder(IFactory factory)
{
    _factory = factory;
    _workflow = new Workflow<TContext>();
}
    
public IWorkflowBuilder<TContext> ThenAsync<TStep, TConfig>(Action<TConfig>? configure) where TStep : IWorkflowOptionsStep<TContext, TConfig>
{
    var step = _factory.Create<TStep>();
    var configuration = Activator.CreateInstance<TConfig>();
    configure?.Invoke(configuration);
    step.SetOptions(configuration);
    _workflow.AddStep(step);
    return this;
}
```

If you have runtime parameters inject the IFactory overloads.

```c#
public MainViewModel(IFactory<string, SubViewModel> subViewModelFactory)
{
    _subViewModelFactory = subViewModelFactory;
}
    
public SubViewModel Create(string parameter)
{
    var subViewModel = _subViewModelFactory.Create(parameter);
    return subViewModel;
}
```



