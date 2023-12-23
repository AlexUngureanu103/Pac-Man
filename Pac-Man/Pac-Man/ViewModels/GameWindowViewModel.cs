using Pac_Man.Business;
using Pac_Man.Domain.Enums;
using System.Collections.ObjectModel;

namespace Pac_Man.ViewModels
{
    public partial class GameWindowViewModel : BaseVM
    {
        public readonly GameLogic _gameLogic;
        public readonly IBoard _board;
        private Timer updateTimer;

        public GameWindowViewModel(IBoard board, GameLogic gameLogic)
        {
            _board = board;
            _gameLogic = gameLogic;
            _gameLogic.SetupGame();
            PopulateBoardImages();
            CreateImageGrid();

            updateTimer = new Timer(UpdateBoard, new object(), 0, 1000);
            _gameLogic.StartGame();
            updateTimer.Change(0, 10);

        }

        public void ReloadBoard()
        {
            updateTimer = new Timer(UpdateBoard, new object(), 0, 1000);
            _gameLogic.StartGame();
            updateTimer.Change(0, 10);
        }

        private int lives;
        public int Lives
        {
            get => lives;
            set
            {
                lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }

        private int score;
        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnPropertyChanged(nameof(Score));
            }
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
            if (imageSources == null)
            {
                imageSources = new ObservableCollection<ObservableCollection<string>>();
                for (int row = 0; row < _board.Rows; row++)
                {
                    var rowList = new ObservableCollection<string>();
                    for (int col = 0; col < _board.Columns; col++)
                    {
                        rowList.Add(_board[row, col].Icon);
                    }
                    imageSources.Add(rowList);
                }
            }
            else
            {
                for (int row = 0; row < _board.Rows; row++)
                {
                    for (int col = 0; col < _board.Columns; col++)
                    {
                        if (_board[row, col].Icon != ImageSources[row][col])
                        {
                            ImageSources[row][col] = _board[row, col].Icon;
                        }
                    }
                }
            }
        }

        public void PopulateBoardImages()
        {
            for (int row = 0; row < _board.Rows; row++)
            {
                for (int col = 0; col < _board.Columns; col++)
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
                        case "i":
                            _board[row, col].Icon = "inky.png";
                            break;
                        case "B":
                            _board[row, col].Icon = "blinky.png";
                            break;
                        case "b":
                            _board[row, col].Icon = "blinky.png";
                            break;
                        case "H":
                            _board[row, col].Icon = "pinky.png";
                            break;
                        case "p":
                            _board[row, col].Icon = "pinky.png";
                            break;
                        case "C":
                            _board[row, col].Icon = "clyde.png";
                            break;
                        case "c":
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
                Lives = _gameLogic.Lifes;
                Score = _gameLogic.Score;
                if (_gameLogic.GameState != GameStateEnum.Running)
                {
                    updateTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    return;
                }
                for (int row = 0; row < _board.Rows; row++)
                {
                    for (int col = 0; col < _board.Columns; col++)
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

        public void ResumeGame()
        {
            updateTimer.Change(0, 10);
        }
    }
}
