namespace Pac_Man.Pages;

using Pac_Man.ViewModels;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Pac_Man.Business;
using Microsoft.Maui;

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


        for (int i = 0; i < rows; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }

        for (int i = 0; i < columns; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        string board = _gameWindowViewModel.GameBoard;
        int number = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var image = new Image();
                char myChar;
                do {
                    if (number == board.Length)
                        break;
                    myChar = board[number];
                    number++;
                    switch (myChar)
                    {
                        case 'P':
                            image.Source = "pac_man.png";
                            break;
                        case 'I':
                            image.Source = "inky.png";
                            break;
                        case 'B':
                            image.Source = "blinky.png";
                            break;
                        case 'H':
                            image.Source = "pinky.png";
                            break;
                        case 'C':
                            image.Source = "clyde.png";
                            break;
                        case '.':
                            image.Source = "pac_dot.png";
                            break;
                        case 'W':
                            image.Source = "block.png";
                            break;
                        default:
                            break;
                    }
                } while (char.IsWhiteSpace(myChar));


                image.WidthRequest = 10;
                image.HeightRequest = 10;
                grid.Children.Add(image);
                Grid.SetRow(image, i);
                Grid.SetColumn(image, j);
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