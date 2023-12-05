using Pac_Man.Domain.Models;

namespace Pac_Man.Business.Movement.Ghost_Algorithms
{
    public class GhostPathAlgorithms : IGhostPathAlgorithms
    {
        private readonly IBoard board;
        private readonly IDijkstraAlgorithm dijkstraAlgorithm;
        private readonly IGhostFleeAlgorithm ghostFleeAlgorithm;

        public GhostPathAlgorithms(IDijkstraAlgorithm dijkstraAlgorithm, IGhostFleeAlgorithm ghostFleeAlgorithm, IBoard board)
        {
            this.dijkstraAlgorithm = dijkstraAlgorithm;
            this.ghostFleeAlgorithm = ghostFleeAlgorithm;
            this.board = board;
        }

        public KeyValuePair<int, int> MainGhostMovements(string ghostName, MoveablesContainer ghost, MoveablesContainer player)
        {
            var ghostPositions = ghost.position;
            var playerPositions = player.position;

            switch (ghostName)
            {
                case "Blinky":
                    {
                        var distance = dijkstraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(playerPositions));
                        if (!distance.ContainsKey(PositionConverter.ConvertPositionsToString(ghostPositions)))
                        {
                            return ghostPositions;
                        }
                        return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                    }
                case "Pinky":
                    {
                        KeyValuePair<int, int> newPlayerPosition;
                        if (board.Columns - playerPositions.Value < 2 || board[playerPositions.Key, playerPositions.Value + 2] is Wall)
                        {
                            newPlayerPosition = new KeyValuePair<int, int>(playerPositions.Key, playerPositions.Value);
                        }
                        else
                        {
                            newPlayerPosition = new KeyValuePair<int, int>(playerPositions.Key, playerPositions.Value + 2);
                        }

                        var distance = dijkstraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(newPlayerPosition));
                        if (!distance.ContainsKey(PositionConverter.ConvertPositionsToString(ghostPositions)))
                        {
                            return ghostPositions;
                        }
                        return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                    }
                case "Inky":
                    {
                        KeyValuePair<int, int> newPlayerPosition;
                        if (playerPositions.Value < 2 || board[playerPositions.Key, playerPositions.Value - 2] is Wall)
                        {
                            newPlayerPosition = new KeyValuePair<int, int>(playerPositions.Key, playerPositions.Value);
                        }
                        else
                        {
                            newPlayerPosition = new KeyValuePair<int, int>(playerPositions.Key, playerPositions.Value - 2);
                        }
                        var distance = dijkstraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(newPlayerPosition));
                        if (!distance.ContainsKey(PositionConverter.ConvertPositionsToString(ghostPositions)))
                        {
                            return ghostPositions;
                        }
                        return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                    }
                case "Clyde":
                    {
                        if (board.CheckIfGhostSeesThePlayer(ghostName))
                        {
                            var nextMove = ghostFleeAlgorithm.Flee(ghost, player);
                            if (nextMove.Key == "" && nextMove.Value == "" || nextMove.Value == "")
                            {
                                return ghostPositions;
                            }

                            return PositionConverter.ConvertPositionsFromString(nextMove.Value);
                        }
                        else
                        {
                            var distance = dijkstraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(playerPositions));
                            if (!distance.ContainsKey(PositionConverter.ConvertPositionsToString(ghostPositions)))
                            {
                                return ghostPositions;
                            }
                            return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                        }
                    }
                default:
                    {
                        return ghostPositions;
                    }
            };
        }

    }
}
