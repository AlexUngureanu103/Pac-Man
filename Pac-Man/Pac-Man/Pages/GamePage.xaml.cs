namespace Pac_Man.Pages;

using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Pac_Man.ApplicationConfiguration;
using Pac_Man.Business.Strategy;
using Pac_Man.Domain.ObserverInterfaces;
using Pac_Man.ViewModels;
using System;

public partial class GamePage : ContentPage, IObserver, ISubject
{
    private readonly IContentPageFactory _contentPageFactory;
    private readonly IPopupFactory _popupFactory;
    private readonly GameWindowViewModel _gameWindowViewModel;
    private List<IObserver> observers = new List<IObserver>();

    public GamePage(GameWindowViewModel gameWindowViewModel, IContentPageFactory contentPageFactory, IPopupFactory popupFactory)
    {
        _contentPageFactory = contentPageFactory;
        _popupFactory = popupFactory;
        _gameWindowViewModel = gameWindowViewModel;
        _gameWindowViewModel._gameLogic.RegisterObserver(this);
        RegisterObserver(_gameWindowViewModel._gameLogic);

        InitializeComponent();

        Loaded += MainPage_Loaded;
        BindingContext = _gameWindowViewModel;
    }

    private void MainPage_Loaded(object sender, EventArgs e)
    {
        entry.Focus();
    }

    private async void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string newText = e.NewTextValue;
        if (!string.IsNullOrEmpty(newText))
        {
            char newChar = newText[newText.Length - 1];
            if (newChar == 'p' || newChar == 'P')
            {
                await PauseMenu();
            }
            else
            {
                _gameWindowViewModel.HandleKeyPress(newChar);
            }
        }

        if (sender is Entry entry)
        {
            entry.Text = string.Empty;
        }
    }

    private bool canUpdate = true;

    public async void Update(string state)
    {
        if (!canUpdate)
        {
            return;
        }
        canUpdate = false;

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

        await Task.Delay(1000);
        canUpdate = true;
    }

    public void NotifyObservers(string state)
    {
        foreach (var observer in observers)
        {
            observer.Update(state);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    private async void PauseButton_Clicked(object sender, EventArgs e)
    {
        await PauseMenu();
    }

    private async Task PauseMenu()
    {
        NotifyObservers("pause");
        var popupPage = _popupFactory.Create<PausePopupPage>();

        var result = await this.ShowPopupAsync(popupPage);

        if (result == null)
        {
            NotifyObservers("lobby");

            await Navigation.PopModalAsync();
        }
        else if (result.Equals("restart"))
        {
            NotifyObservers("restart");
            _gameWindowViewModel.PopulateBoardImages();
            _gameWindowViewModel.ResumeGame();
        }
        else
        {
            if (result is StrategyEnum difficulty)
            {
                _gameWindowViewModel._gameLogic.Update("changeDifficulty" + '_' + difficulty.ToString());
            }
            NotifyObservers("resume");
            _gameWindowViewModel.ResumeGame();
            entry.Focus();
        }
    }
}