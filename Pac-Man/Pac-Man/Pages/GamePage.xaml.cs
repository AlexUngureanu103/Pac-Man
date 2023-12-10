namespace Pac_Man.Pages;
using Pac_Man.ViewModels;

public partial class GamePage : ContentPage
{
    private readonly GameWindowViewModel gameWindowViewModel;
    public GamePage()
    {
        gameWindowViewModel = new GameWindowViewModel();
        InitializeComponent();
        Loaded += MainPage_Loaded;
        BindingContext = gameWindowViewModel;
    }

    private void MainPage_Loaded(object sender, EventArgs e)
    {
        entry.Focus();
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string newText = e.NewTextValue;
        if (!string.IsNullOrEmpty(newText))
        {
            char newChar = newText[newText.Length - 1];
            gameWindowViewModel.HandleKeyPress(newChar);
        }
    }


    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}