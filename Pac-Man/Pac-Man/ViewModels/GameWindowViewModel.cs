using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Domain.Enums;

namespace Pac_Man.ViewModels
{
    public partial class GameWindowViewModel : BaseVM
    {
        private readonly GameLogic gameLogic;
        private readonly IBoard board;
        private Timer updateTimer;

        public GameWindowViewModel()
        {
            //To inject dependencies!
            IGameCharacters gameCharacters = new GameCharacters();
            board = new Board(gameCharacters);
            IGraph graph = new Graph(board, gameCharacters);
            IDijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm(graph);
            IGhostFleeAlgorithm ghostFleeAlgorithm = new GhostFleeAlgorithm(graph);
            IGhostPathAlgorithms ghostPathAlgorithms = new GhostPathAlgorithms(dijkstraAlgorithm, ghostFleeAlgorithm, board);
            gameLogic = new GameLogic(dijkstraAlgorithm, ghostFleeAlgorithm, ghostPathAlgorithms, board, graph);

            updateTimer = new Timer(UpdateBoard, new object(), 0, 1000);
            gameLogic.StartGame();
            updateTimer.Change(0, 250);
        }

        private void UpdateBoard(object state)
        {
            lock (this)
            {
                GameBoard = board.ToString();
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
                    gameLogic.MoveCharacter(InputKeyEnum.Up);
                    break;
                case 'a':
                    gameLogic.MoveCharacter(InputKeyEnum.Left);
                    break;
                case 's':
                    gameLogic.MoveCharacter(InputKeyEnum.Down);
                    break;
                case 'd':
                    gameLogic.MoveCharacter(InputKeyEnum.Right);
                    break;
                default:
                    gameLogic.MoveCharacter(InputKeyEnum.Invalid);
                    break;
            }
            GameBoard = board.ToString();
        }
    }
}
