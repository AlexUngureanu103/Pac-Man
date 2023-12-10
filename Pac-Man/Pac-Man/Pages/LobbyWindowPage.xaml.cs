namespace Pac_Man.Pages;

public partial class LobbyWindowPage : ContentPage
{
    public LobbyWindowPage()
    {
        InitializeComponent();
    }

    private async void GamePageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new GamePage());
    }

    private async void AboutPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AboutPage());
    }
}