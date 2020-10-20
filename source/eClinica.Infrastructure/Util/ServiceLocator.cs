using Microsoft.Extensions.DependencyInjection;
using System;

namespace eClinica.Infrastructure.Util
{
    public class ServiceLocator
    {
        private readonly ServiceProvider _currentServiceProvider;
        private static ServiceProvider _serviceProvider;

        public ServiceLocator(ServiceProvider currentServiceProvider)
        {
            _currentServiceProvider = currentServiceProvider;
        }

        public static ServiceLocator Current => new ServiceLocator(_serviceProvider);

        public static void SetLocatorProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetInstance(Type serviceType)
        {
            return _currentServiceProvider.GetService(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return _currentServiceProvider.GetService<TService>();
        }

        public T CreateInstance<T>(params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance<T>(_currentServiceProvider, parameters);
        }

        public object CreateInstance(Type type, params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance(_currentServiceProvider, type, parameters);
        }
    }
}
