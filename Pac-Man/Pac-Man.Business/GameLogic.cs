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

        public string PlayerName { get; set; } = "Guest";

        public GameLogic(IDijkstraAlgorithm dijkstraAlgorithm, IGhostFleeAlgorithm ghostFleeAlgorithm, IGhostPathAlgorithms ghostPathAlgorithms)
        {
            IGameCharacters gameCharacters = new GameCharacters();
            board = new Board(gameCharacters);
            graph = new Graph(board, gameCharacters);

            this.dijkstraAlgorithm = dijkstraAlgorithm;
            this.ghostFleeAlgorithm = ghostFleeAlgorithm;
            this.ghostPathAlgorithms = ghostPathAlgorithms;

            gameState = GameStateEnum.Lobby;
            playerState = PlayerStateEnum.Alive;
        }

        public void NotifyObservers()
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
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
