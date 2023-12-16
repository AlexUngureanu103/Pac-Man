namespace Pac_Man.Pages;

using Microsoft.Maui.Controls;
using Pac_Man.ViewModels;

public partial class GamePage : ContentPage
{
    private readonly GameWindowViewModel _gameWindowViewModel;

    public GamePage(GameWindowViewModel gameWindowViewModel)
    {
        _gameWindowViewModel = gameWindowViewModel;
        InitializeComponent();

        Loaded += MainPage_Loaded;
        BindingContext = _gameWindowViewModel;
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
            _gameWindowViewModel.HandleKeyPress(newChar);
        }
    }


    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}