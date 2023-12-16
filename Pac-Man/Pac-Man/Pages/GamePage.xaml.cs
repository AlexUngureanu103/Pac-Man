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

        CreateImageGrid(23, 23);
    }

    private void CreateImageGrid(int rows, int columns)
    {
        var grid = new Grid();

        int imageHeight = 14;
        int imageWidth = 14;
        int marginBetweenImages = 2;

        grid.HeightRequest = rows * (imageHeight + marginBetweenImages);
        grid.WidthRequest = columns * (imageWidth + marginBetweenImages);


        for (int row = 0; row < rows; row++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }

        for (int col = 0; col < columns; col++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        var board = _gameWindowViewModel._board;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                var image = new Image();

                image.Source = board[row, col].Icon;

                image.WidthRequest = 10;
                image.HeightRequest = 10;
                grid.Children.Add(image);
                Grid.SetRow(image, row);
                Grid.SetColumn(image, col);
            }
        }

        mainStackLayout?.Children.Add(grid);
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