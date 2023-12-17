﻿using Pac_Man.Business;
using Pac_Man.Domain.Enums;
using System.Collections.ObjectModel;

namespace Pac_Man.ViewModels
{
    public partial class GameWindowViewModel : BaseVM
    {
        private readonly GameLogic _gameLogic;
        public readonly IBoard _board;
        private Timer updateTimer;

        public GameWindowViewModel(IBoard board, GameLogic gameLogic)
        {
            _board = board;
            _gameLogic = gameLogic;
            PopulateBoardImages();
            CreateImageGrid();

            updateTimer = new Timer(UpdateBoard, new object(), 0, 1000);
            gameLogic.StartGame();
            updateTimer.Change(0, 10);

        }

        private ObservableCollection<ObservableCollection<string>> imageSources;
        public ObservableCollection<ObservableCollection<string>> ImageSources
        {
            get { return imageSources; }
            set
            {
                imageSources = value;
                OnPropertyChanged(nameof(ImageSources));
            }
        }


        private void CreateImageGrid()
        {
            imageSources = new ObservableCollection<ObservableCollection<string>>();
            for (int row = 0; row < 23; row++)
            {
                var rowList = new ObservableCollection<string>();
                for (int col = 0; col < 23; col++)
                {
                    rowList.Add(_board[row, col].Icon);
                }
                imageSources.Add(rowList);
            }
        }

        private void PopulateBoardImages()
        {
            for (int row = 0; row < 23; row++)
            {
                for (int col = 0; col < 23; col++)
                {
                    var piece = _board[row, col].ToString().Trim();
                    switch (piece)
                    {
                        case "P":
                            _board[row, col].Icon = "pac_man.png";
                            break;
                        case "I":
                            _board[row, col].Icon = "inky.png";
                            break;
                        case "B":
                            _board[row, col].Icon = "blinky.png";
                            break;
                        case "H":
                            _board[row, col].Icon = "pinky.png";
                            break;
                        case "C":
                            _board[row, col].Icon = "clyde.png";
                            break;
                        case ".":
                            _board[row, col].Icon = "pac_dot.png";
                            break;
                        case "W":
                            _board[row, col].Icon = "block.png";
                            break;
                        default:
                            _board[row, col].Icon = "black_block.png";
                            break;
                    }
                }
            }
        }

        private void UpdateBoard(object state)
        {
            lock (this)
            {
                for (int row = 0; row < 23; row++)
                {
                    for (int col = 0; col < 23; col++)
                    {
                        if (_board[row, col].Icon != ImageSources[row][col])
                        {
                            ImageSources[row][col] = _board[row, col].Icon;
                        }
                    }
                }
            }
        }

        public void HandleKeyPress(char key)
        {
            switch (char.ToLower(key))
            {
                case 'w':
                    _gameLogic.MoveCharacter(InputKeyEnum.Up);
                    break;
                case 'a':
                    _gameLogic.MoveCharacter(InputKeyEnum.Left);
                    break;
                case 's':
                    _gameLogic.MoveCharacter(InputKeyEnum.Down);
                    break;
                case 'd':
                    _gameLogic.MoveCharacter(InputKeyEnum.Right);
                    break;
                default:
                    _gameLogic.MoveCharacter(InputKeyEnum.Invalid);
                    break;
            }
        }
    }
}
