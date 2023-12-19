namespace Pac_Man.ApplicationConfiguration
{
    public interface IContentPageFactory
    {
        T Create<T>() where T : ContentPage;
    }
}
