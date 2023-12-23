using CommunityToolkit.Maui.Views;
using Pac_Man.Business.Strategy;

namespace Pac_Man.Pages;
public partial class PausePopupPage : Popup
{
    private readonly List<StrategyEnum> difficulties = Enum.GetValues(typeof(StrategyEnum)).Cast<StrategyEnum>().ToList();

    public PausePopupPage()
    {
        InitializeComponent();
    }

    private void Resume_Clicked(object sender, EventArgs e)
    {
        Close(true);
    }

    private void Lobby_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void Change_Difficulty_Clicked(object sender, EventArgs e)
    {
        itemPicker.ItemsSource = difficulties;
        itemPicker.IsVisible = true;
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedIdx = itemPicker.SelectedIndex;
        StrategyEnum selectedItem = StrategyEnum.Normal;

        if (selectedIdx != -1)
        {
            selectedItem = difficulties[selectedIdx];
            itemPicker.IsVisible = false;
        }
        Close(selectedItem);
    }

    private void Restart_Clicked(object sender, EventArgs e)
    {
        Close("restart");
    }
}