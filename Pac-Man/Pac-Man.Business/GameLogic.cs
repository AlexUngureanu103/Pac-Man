using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Domain.Enums;
using Pac_Man.Domain.Models;
using Pac_Man.Domain.ObserverInterfaces;

namespace Pac_Man.Business
{
    public class GameLogic : IObserver, ISubject
    {
        private IBoard board;
        private IGraph graph;
        private readonly IDijkstraAlgorithm dijkstraAlgorithm;
        private readonly IGhostFleeAlgorithm ghostFleeAlgorithm;
        private readonly IGhostPathAlgorithms ghostPathAlgorithms;
        private GameStateEnum gameState;
        private PlayerStateEnum playerState;
        private List<IObserver> observers = new List<IObserver>();

        private Timer ghostMoveTimer;

        public string PlayerName { get; set; } = "Guest";

        public GameLogic(IDijkstraAlgorithm dijkstraAlgorithm, IGhostFleeAlgorithm ghostFleeAlgorithm, IGhostPathAlgorithms ghostPathAlgorithms, IBoard board, IGraph graph)
        {
            this.dijkstraAlgorithm = dijkstraAlgorithm;
            this.ghostFleeAlgorithm = ghostFleeAlgorithm;
            this.ghostPathAlgorithms = ghostPathAlgorithms;
            this.board = board;
            this.graph = graph;

            gameState = GameStateEnum.Lobby;
            playerState = PlayerStateEnum.Alive;

            ghostMoveTimer = new Timer(OnGhostMoveTimerCallback, new object(), Timeout.Infinite, 1000);
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

        public void Update(string state)
        {
            switch (state)
            {
                case "lobby":
                    {
                        gameState = GameStateEnum.Lobby;
                        break;
                    }
                case "start":
                    {
                        gameState = GameStateEnum.Starting;
                        break;
                    }
                case "run":
                    {
                        gameState = GameStateEnum.Running;
                        break;
                    }
                case "pause":
                    {
                        gameState = GameStateEnum.Paused;
                        break;
                    }
                case "end":
                    {
                        gameState = GameStateEnum.End;
                        break;
                    }
                case "stop":
                    {
                        gameState = GameStateEnum.Stop;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void StartGame()
        {
            gameState = GameStateEnum.Running;
            ghostMoveTimer.Change(0, 1000);
            board.PrintBoard();
        }
        public void StopGame()
        {
            gameState = GameStateEnum.End;
            ghostMoveTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void OnGhostMoveTimerCallback(object state)
        {
            lock (this)
            {
                MoveGhosts();
            }
        }

        private void MoveGhosts()
        {
            if (gameState == GameStateEnum.Running)
            {
                foreach (var ghost in board.GameCharacters.Ghosts)
                {
                    var newPosition = ghostPathAlgorithms.MainGhostMovements(ghost.Key, ghost.Value, board.GameCharacters.Character);
                    if (board.GameCharacters.Ghosts[ghost.Key].position.Key == newPosition.Key &&
                        board.GameCharacters.Ghosts[ghost.Key].position.Value == newPosition.Value)
                    {
                        continue;
                    }
                    UpdateGhostsPosition(ghost.Key, newPosition.Key, newPosition.Value);
                    board.PrintBoard();
                }
            }
        }

        private void UpdateGhostsPosition(string ghostName, int newGhostColumnRow, int newGhostPositionColumnn)
        {
            var ghostRow = board.GameCharacters.Ghosts[ghostName].position.Key;
            var ghostColumn = board.GameCharacters.Ghosts[ghostName].position.Value;

            var newPosition = new KeyValuePair<int, int>(newGhostColumnRow, newGhostPositionColumnn);

            board.SwitchPieces(board.GameCharacters.Ghosts[ghostName].position, newPosition);

            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Ghosts[ghostName].position)].IsGhost = false;
            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Ghosts[ghostName].position)].IsOccupied = false;

            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsGhost = true;
            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsOccupied = true;

            board.GameCharacters.Ghosts[ghostName].position = newPosition;
            graph.GameCharacters.Ghosts[ghostName].position = newPosition;
        }

        private void ModifyCharacterPosition(int newCharacterRow, int newCharacterPositionColumn)
        {
            var characterRow = board.GameCharacters.Character.position.Key;
            var characterColumn = board.GameCharacters.Character.position.Value;

            var newPosition = new KeyValuePair<int, int>(newCharacterRow, newCharacterPositionColumn);

            if (board[characterRow, characterColumn - 1] is Empty)
            {
                board.SwitchPieces(board.GameCharacters.Character.position, newPosition);
            }
            else
            {
                board[characterRow, characterColumn] = new Empty();
                board[newCharacterRow, newCharacterPositionColumn] = board.GameCharacters.Character.piece;
            }

            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Character.position)].IsPacMan = false;
            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Character.position)].IsOccupied = false;

            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsPacMan = true;
            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsOccupied = true;

            board.GameCharacters.Character.position = newPosition;
            graph.GameCharacters.Character.position = newPosition;
        }

        public void MoveCharacter(InputKeyEnum inputKey)
        {
            int characterRow = board.GameCharacters.Character.position.Key;
            int characterColumn = board.GameCharacters.Character.position.Value;

            switch (inputKey)
            {
                case InputKeyEnum.Left:
                    {
                        if (characterColumn > 0 && board[characterRow, characterColumn - 1].canMoveIn)
                        {
                            ModifyCharacterPosition(characterRow, characterColumn - 1);
                        }

                        break;
                    }

                case InputKeyEnum.Right:
                    {
                        if (characterColumn + 1 < board.Columns && board[characterRow, characterColumn + 1].canMoveIn)
                        {
                            ModifyCharacterPosition(characterRow, characterColumn + 1);
                        }
                        break;
                    }

                case InputKeyEnum.Up:
                    {
                        if (characterRow > 0 && board[characterRow - 1, characterColumn].canMoveIn)
                        {
                            ModifyCharacterPosition(characterRow - 1, characterColumn);
                        }
                        break;
                    }

                case InputKeyEnum.Down:
                    {
                        if (characterRow + 1 < board.Rows && board[characterRow + 1, characterColumn].canMoveIn)
                        {
                            ModifyCharacterPosition(characterRow + 1, characterColumn);
                        }
                        break;
                    }
            }
        }
    }
}
