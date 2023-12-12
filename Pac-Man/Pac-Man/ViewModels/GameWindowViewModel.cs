using Pac_Man.Business;
using Pac_Man.Domain.Enums;

namespace Pac_Man.ViewModels
{
    public partial class GameWindowViewModel : BaseVM
    {
        private readonly GameLogic _gameLogic;
        private readonly IBoard _board;
        private Timer updateTimer;

        public GameWindowViewModel(IBoard board, GameLogic gameLogic)
        {
            _board = board;
            _gameLogic = gameLogic;


            updateTimer = new Timer(UpdateBoard, new object(), 0, 1000);
            gameLogic.StartGame();
            updateTimer.Change(0, 250);
        }

        private void UpdateBoard(object state)
        {
            lock (this)
            {
                GameBoard = _board.ToString();
            }
        }

        private string _gameBoard;
        public string GameBoard
        {
            get { return _gameBoard; }
            set
            {
                _gameBoard = value;
                OnPropertyChanged(nameof(GameBoard));
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
            GameBoard = _board.ToString();
        }
    }
}
