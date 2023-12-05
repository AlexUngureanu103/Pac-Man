namespace Pac_Man.Pages;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}