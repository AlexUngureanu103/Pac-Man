using Pac_Man.ApplicationConfiguration;
using Pac_Man.ViewModels;

namespace Pac_Man.Pages;

public partial class LobbyWindowPage : ContentPage
{
    private readonly IContentPageFactory _contentPageFactory;
    private readonly LobbyWindowViewModel _lobbyWindowViewModel;

    public LobbyWindowPage(IContentPageFactory contentPageFactory, LobbyWindowViewModel lobbyWindowViewModel)
    {
        _contentPageFactory = contentPageFactory;
        _lobbyWindowViewModel = lobbyWindowViewModel;
        InitializeComponent();

        BindingContext = _lobbyWindowViewModel;
    }

    private async void GamePageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(_contentPageFactory.Create<GamePage>());
    }

    private async void AboutPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(_contentPageFactory.Create<AboutPage>());
    }
}