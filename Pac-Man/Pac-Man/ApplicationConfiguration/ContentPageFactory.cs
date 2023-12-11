using Microsoft.Extensions.DependencyInjection;

namespace Pac_Man.ApplicationConfiguration
{
    public class ContentPageFactory : IContentPageFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ContentPageFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T Create<T>() where T : ContentPage
        {
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T));
        }
    }
}
