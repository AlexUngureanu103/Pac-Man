using CommunityToolkit.Maui.Views;
using Pac_Man.ApplicationConfiguration;
using Pac_Man.Domain.ObserverInterfaces;

namespace Pac_Man.Pages;

public partial class PausePopupPage: Popup
{
    public PausePopupPage()
	{
        InitializeComponent();
	}

    private void Resume_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private async void Lobby_Clicked(object sender, EventArgs e)
    {
        Close(true);
    }
}