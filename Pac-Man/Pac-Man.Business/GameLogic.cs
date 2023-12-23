using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Strategy;
using Pac_Man.Domain;
using Pac_Man.Domain.Enums;
using Pac_Man.Domain.Models;
using Pac_Man.Domain.ObserverInterfaces;

namespace Pac_Man.Business
{
    public class GameLogic : IGameLogic
    {
        private IGameCharacters gameCharactersInitialPos = new GameCharacters();
        private IBoard board;
        private IGraph graph;

        private List<IObserver> observers = new List<IObserver>();
        private IStrategyFactory strategyFactory;
        private IStrategy strategy;

        private Empty emptySpace = new();
        private Timer ghostMoveTimer;

        private int maxScore = 0;

        public int Lifes { get; private set; } = 3;
        public int Score { get; private set; } = 0;
        public GameStateEnum GameState { get; private set; }
        public PlayerStateEnum PlayerState { get; private set; }
        public string PlayerName { get; set; } = "Guest";

        public GameLogic(IBoard board, IGraph graph, IStrategyFactory strategyFactory)
        {
            GameState = GameStateEnum.Lobby;
            PlayerState = PlayerStateEnum.SpawnProtected;

            this.board = board;
            this.graph = graph;
            this.strategyFactory = strategyFactory;

            var strategy = strategyFactory.GetStrategy(StrategyEnum.Normal);
            this.strategy = strategy;

            gameCharactersInitialPos.Character.position = board.GameCharacters.Character.position;
            gameCharactersInitialPos.Ghosts[Ghosts.Blinky].position = board.GameCharacters.Ghosts[Ghosts.Blinky].position;
            gameCharactersInitialPos.Ghosts[Ghosts.Pinky].position = board.GameCharacters.Ghosts[Ghosts.Pinky].position;
            gameCharactersInitialPos.Ghosts[Ghosts.Inky].position = board.GameCharacters.Ghosts[Ghosts.Inky].position;
            gameCharactersInitialPos.Ghosts[Ghosts.Clyde].position = board.GameCharacters.Ghosts[Ghosts.Clyde].position;

            maxScore = this.board.ToString().Count(x => x == '.');
            ghostMoveTimer = new Timer(OnGhostMoveTimerCallback, new object(), Timeout.Infinite, 1000);
        }

        private void ChangeStrategy(StrategyEnum strategyEnum)
        {
            if (strategyEnum != StrategyEnum.Back)
            {
                strategy = strategyFactory.GetStrategy(strategyEnum);
            }
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
                        GameState = GameStateEnum.Lobby;
                        break;
                    }
                case "start":
                    {
                        GameState = GameStateEnum.Starting;
                        GameState = GameStateEnum.Running;
                        break;
                    }
                case "resume":
                    {
                        GameState = GameStateEnum.Running;
                        break;
                    }
                case "pause":
                    {
                        GameState = GameStateEnum.Paused;
                        break;
                    }
                case "end":
                    {
                        GameState = GameStateEnum.End;
                        break;
                    }
                case "stop":
                    {
                        GameState = GameStateEnum.Stop;
                        break;
                    }
                case "restart":
                    {
                        GameState = GameStateEnum.Stop;
                        SetupGame();
                        GameState = GameStateEnum.Running;
                        break;
                    }
                case var expression when expression.Contains("changeDifficulty"):
                    {
                        var strategyEnum = (StrategyEnum)Enum.Parse(typeof(StrategyEnum), expression.Split("_")[1]);
                        ChangeStrategy(strategyEnum);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void SetupGame()
        {
            GameState = GameStateEnum.Paused;

            board.BoardRestart(gameCharactersInitialPos);
            //board.ClassicBoardGneration();
            board.SmallerBoardGneration();
            graph.GraphSetup(board);

            Lifes = 3;
            maxScore = board.ToString().Count(x => x == '.');
            Score = 0;
        }

        public void StartGame()
        {
            GameState = GameStateEnum.Running;
            ghostMoveTimer.Change(0, 250);
        }

        public void StopGame()
        {
            GameState = GameStateEnum.End;
            ghostMoveTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void OnGhostMoveTimerCallback(object state)
        {
            lock (this)
            {
                MoveGhosts();
            }
        }

        private void GhostCharacterInteracts()
        {
            Lifes--;
            if (Lifes > 0)
            {
                PlayerState = PlayerStateEnum.SpawnProtected;
                board.BoardRestart(gameCharactersInitialPos);
                graph.GraphRestart(gameCharactersInitialPos);

                board.GameCharacters.Character.position = gameCharactersInitialPos.Character.position;
                board.GameCharacters.Ghosts[Ghosts.Blinky].position = gameCharactersInitialPos.Ghosts[Ghosts.Blinky].position;
                board.GameCharacters.Ghosts[Ghosts.Pinky].position = gameCharactersInitialPos.Ghosts[Ghosts.Pinky].position;
                board.GameCharacters.Ghosts[Ghosts.Inky].position = gameCharactersInitialPos.Ghosts[Ghosts.Inky].position;
                board.GameCharacters.Ghosts[Ghosts.Clyde].position = gameCharactersInitialPos.Ghosts[Ghosts.Clyde].position;

                maxScore = board.ToString().Count(x => x == '.');
            }
            else
            {
                StopGame();
                PlayerState = PlayerStateEnum.Dead;
                NotifyObservers("stop");
            }
        }

        private void MoveGhosts()
        {
            if (GameState == GameStateEnum.Running && PlayerState != PlayerStateEnum.SpawnProtected)
            {
                foreach (var ghost in board.GameCharacters.Ghosts)
                {
                    var newPosition = strategy.MoveGhosts(ghost, board.GameCharacters.Character);

                    if ((board.GameCharacters.Ghosts[ghost.Key].position.Key == newPosition.Key &&
                        board.GameCharacters.Ghosts[ghost.Key].position.Value == newPosition.Value) ||
                        (graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsGhost))
                    {
                        continue;
                    }
                    UpdateGhostsPosition(ghost.Key, newPosition.Key, newPosition.Value);
                }
            }
        }

        private void UpdateGhostsPosition(string ghostName, int newGhostRow, int newGhostPositionColumnn)
        {
            var ghostRow = board.GameCharacters.Ghosts[ghostName].position.Key;
            var ghostColumn = board.GameCharacters.Ghosts[ghostName].position.Value;

            var newPosition = new KeyValuePair<int, int>(newGhostRow, newGhostPositionColumnn);

            if (board.GameCharacters.Character.position.Key == newGhostRow && board.GameCharacters.Character.position.Value == newGhostPositionColumnn)
            {
                GhostCharacterInteracts();
                return;
            }

            board.SwitchPieces(board.GameCharacters.Ghosts[ghostName].position, newPosition);

            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Ghosts[ghostName].position)].IsGhost = false;
            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Ghosts[ghostName].position)].IsOccupied = false;

            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsGhost = true;
            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsOccupied = true;

            board.GameCharacters.Ghosts[ghostName].position = newPosition;
            graph.GameCharacters.Ghosts[ghostName].position = newPosition;
        }

        private void ModifyCharacterPosition(int newCharacterRow, int newCharacterColumn)
        {
            var characterRow = board.GameCharacters.Character.position.Key;
            var characterColumn = board.GameCharacters.Character.position.Value;

            var newPosition = new KeyValuePair<int, int>(newCharacterRow, newCharacterColumn);
            if (board[newCharacterRow, newCharacterColumn] is Ghost)
            {
                GhostCharacterInteracts();
                return;
            }
            if (board[newCharacterRow, newCharacterColumn] is Wall)
            {
                return;
            }

            if (board[newCharacterRow, newCharacterColumn] is Food)
            {
                Score++;
                Console.Write(Score);
                Console.WriteLine();
            }

            if (board[newCharacterRow, newCharacterColumn] is Empty)
            {
                board.SwitchPieces(board.GameCharacters.Character.position, newPosition);
            }
            else
            {
                board[characterRow, characterColumn] = emptySpace;
                board.GameCharacters.Character.position = newPosition;
                board[newCharacterRow, newCharacterColumn] = board.GameCharacters.Character.piece;
            }

            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Character.position)].IsPacMan = false;
            graph.Nodes[PositionConverter.ConvertPositionsToString(board.GameCharacters.Character.position)].IsOccupied = false;

            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsPacMan = true;
            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsOccupied = true;

            graph.GameCharacters.Character.position = newPosition;
        }

        public void MoveCharacter(InputKeyEnum inputKey)
        {
            if (GameState != GameStateEnum.Running)
            {
                return;
            }
            if (PlayerState == PlayerStateEnum.SpawnProtected)
            {
                PlayerState = PlayerStateEnum.Alive;
            }
            if (maxScore == Score)
            {
                StopGame();
                GameState = GameStateEnum.End;
                NotifyObservers("end");
            }

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
