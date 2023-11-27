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
        private Board board;
        private Graph graph;
        private readonly DijkstraAlgorithm dijkstraAlgorithm;
        private readonly GhostFleeAlgorithm ghostFleeAlgorithm;
        private readonly GhostPathAlgorithms ghostPathAlgorithms;
        private GameStateEnum gameState;
        private PlayerStateEnum playerState;

        public string PlayerName { get; set; }

        public GameLogic(DijkstraAlgorithm dijkstraAlgorithm, GhostFleeAlgorithm ghostFleeAlgorithm, GhostPathAlgorithms ghostPathAlgorithms)
        {
            board = new Board();
            graph = new Graph(board);

            this.dijkstraAlgorithm = dijkstraAlgorithm;
            this.ghostFleeAlgorithm = ghostFleeAlgorithm;
            this.ghostPathAlgorithms = ghostPathAlgorithms;

            gameState = GameStateEnum.Lobby;
            playerState = PlayerStateEnum.Alive;
            this.ghostPathAlgorithms = ghostPathAlgorithms;
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
            int characterRow = board.Character.position.Key;
            int characterColumn = board.Character.position.Value;

            KeyValuePair<int, int> newPosition = new KeyValuePair<int, int>(newCharacterRow, newCharacterPositionColumn);

            if (board[characterRow, characterColumn - 1] is Empty)
            {
                board.SwitchPieces(board.Character.position, newPosition);
            }
            else
            {
                board[characterRow, characterColumn] = new Empty();
                board[newCharacterRow, newCharacterPositionColumn] = board.Character.piece;
            }

            graph.Nodes[PositionConverter.ConvertPositionsToString(board.Character.position)].IsPacMan = false;
            graph.Nodes[PositionConverter.ConvertPositionsToString(board.Character.position)].IsOccupied = false;

            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsPacMan = true;
            graph.Nodes[PositionConverter.ConvertPositionsToString(newPosition)].IsOccupied = true;

            board.Character.position = newPosition;
            graph.Character.position = newPosition;
        }

        public void MoveCharacter(InputKeyEnum inputKey)
        {
            int characterRow = board.Character.position.Key;
            int characterColumn = board.Character.position.Value;

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
