namespace Pac_Man.Pages;

using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Pac_Man.ApplicationConfiguration;
using Pac_Man.Domain.ObserverInterfaces;
using Pac_Man.ViewModels;

public partial class GamePage : ContentPage, IObserver
{
    private readonly IContentPageFactory _contentPageFactory;
    private readonly IPopupFactory _popupFactory;
    private readonly GameWindowViewModel _gameWindowViewModel;

    public GamePage(GameWindowViewModel gameWindowViewModel, IContentPageFactory contentPageFactory, IPopupFactory popupFactory)
    {
        _contentPageFactory = contentPageFactory;
        _popupFactory = popupFactory;
        _gameWindowViewModel = gameWindowViewModel;
        _gameWindowViewModel._gameLogic.RegisterObserver(this);

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

        if(sender is Entry entry)
        {
            entry.Text = string.Empty;
        }
    }

    public async void Update(string state)
    {
        await Dispatcher.DispatchAsync
            (() =>
            {
                switch (state)
                {
                    case "end":
                        DisplayAlert("Game Over", "You won!", "OK");
                        Navigation.PushModalAsync(_contentPageFactory.Create<LobbyWindowPage>());
                        break;

                    case "stop":
                        DisplayAlert("Game Over", "You lost!", "OK");
                        Navigation.PushModalAsync(_contentPageFactory.Create<LobbyWindowPage>());
                        break;

                    default:
                        break;
                }
            });

    }

    private async void PauseButton_Clicked(object sender, EventArgs e)
    {
        //_gameWindowViewModel._gameLogic.GameState = Domain.Enums.GameStateEnum.Paused;
        var popupPage = _popupFactory.Create<PausePopupPage>();

        var result = await this.ShowPopupAsync(popupPage);

        if (result != null)
        {
            await Navigation.PopModalAsync();
        }
    }



}