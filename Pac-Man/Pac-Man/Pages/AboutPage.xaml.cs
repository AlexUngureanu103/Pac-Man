namespace Pac_Man.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}