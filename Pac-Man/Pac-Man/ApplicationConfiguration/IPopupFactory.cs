using CommunityToolkit.Maui.Views;

namespace Pac_Man.ApplicationConfiguration
{
    public interface IPopupFactory
    {
        T Create<T>() where T : Popup;
    }
}
