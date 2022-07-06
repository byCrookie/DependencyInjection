﻿namespace DependencyInjection.Factory;

public class Factory : IFactory
{
    private readonly IServiceProvider _serviceProvider;

    public Factory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T Create<T>() where T : notnull
    {
        if (_serviceProvider.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"Type {typeof(T).FullName} can not be resolved. Try register explicatly.");
        }

        return service;
    }

    public object Create(Type type)
    {
        var service = _serviceProvider.GetService(type);
        
        if (service is null)
        {
            throw new ArgumentException($"Type {type.FullName} can not be resolved. Try register explicatly.");
        }
        
        return service;
    }

    public T Create<T>(Type type) where T : notnull
    {
        if (_serviceProvider.GetService(type) is not T service)
        {
            throw new ArgumentException($"Type {typeof(T).FullName} can not be resolved. Try register explicatly.");
        }

        return service;
    }
}

public class Factory<T> : IFactory<T> where T : notnull
{
    private readonly Func<T> _factory;

    public Factory(Func<T> factory)
    {
        _factory = factory;
    }

    public T Create()
    {
        return _factory();
    }
}

public class Factory<TParameter, T> : IFactory<TParameter, T> where T : notnull
{
    private readonly Func<TParameter, T> _factory;

    public Factory(Func<TParameter, T> factory)
    {
        _factory = factory;
    }

    public T Create(TParameter parameter)
    {
        return _factory(parameter);
    }
}

public class Factory<TParameter1, TParameter2, T> : IFactory<TParameter1, TParameter2, T> where T : notnull
{
    private readonly Func<TParameter1, TParameter2, T> _factory;

    public Factory(Func<TParameter1, TParameter2, T> factory)
    {
        _factory = factory;
    }

    public T Create(TParameter1 parameter1, TParameter2 parameter2)
    {
        return _factory(parameter1, parameter2);
    }
}

public class Factory<TParameter1, TParameter2, TParameter3, T> : IFactory<TParameter1, TParameter2, TParameter3, T> where T : notnull
{
    private readonly Func<TParameter1, TParameter2, TParameter3, T> _factory;

    public Factory(Func<TParameter1, TParameter2, TParameter3, T> factory)
    {
        _factory = factory;
    }

    public T Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3)
    {
        return _factory(parameter1, parameter2, parameter3);
    }
}

public class Factory<TParameter1, TParameter2, TParameter3, TParameter4, T> : IFactory<TParameter1, TParameter2, TParameter3, TParameter4, T> where T : notnull
{
    private readonly Func<TParameter1, TParameter2, TParameter3, TParameter4, T> _factory;

    public Factory(Func<TParameter1, TParameter2, TParameter3, TParameter4, T> factory)
    {
        _factory = factory;
    }

    public T Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3, TParameter4 parameter4)
    {
        return _factory(parameter1, parameter2, parameter3, parameter4);
    }
}

public class Factory<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T> : IFactory<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T> where T : notnull
{
    private readonly Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T> _factory;

    public Factory(Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T> factory)
    {
        _factory = factory;
    }

    public T Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3, TParameter4 parameter4, TParameter5 parameter5)
    {
        return _factory(parameter1, parameter2, parameter3, parameter4, parameter5);
    }
}