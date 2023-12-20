using CommunityToolkit.Maui.Views;
using Pac_Man.ApplicationConfiguration;
using Pac_Man.ViewModels;

namespace Pac_Man.Pages;

public partial class LobbyWindowPage : ContentPage
{
    private readonly IContentPageFactory _contentPageFactory;
    private readonly IPopupFactory _popupFactory;
    private readonly LobbyWindowViewModel _lobbyWindowViewModel;

    public LobbyWindowPage(IContentPageFactory contentPageFactory, IPopupFactory popupFactory, LobbyWindowViewModel lobbyWindowViewModel)
    {
        _contentPageFactory = contentPageFactory;
        _popupFactory = popupFactory;
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

    private void ControlsButton_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(_popupFactory.Create<ControlsPopup>());
    }
}