using CommunityToolkit.Maui.Views;

namespace Pac_Man.Pages;

public partial class ControlsPopup : Popup
{
	public ControlsPopup()
	{
		InitializeComponent();
	}

    private void Close_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}