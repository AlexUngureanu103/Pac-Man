using CommunityToolkit.Maui.Views;

namespace Pac_Man.ApplicationConfiguration
{
    public class PopupFactory : IPopupFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PopupFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T Create<T>() where T : Popup
        {
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T));
        }
    }
}
