namespace Pac_Man.Business.Movement.Ghost_Algorithms
{
    public class GhostPathAlgorithms
    {
        private Board board;
        private DijkstraAlgorithm dijsktraAlgorithm;
        private GhostFleeAlgorithm ghostFleeAlgorithm;

        public GhostPathAlgorithms(DijkstraAlgorithm dijkstraAlgorithm, GhostFleeAlgorithm ghostFleeAlgorithm, Board board)
        {
            dijsktraAlgorithm = dijkstraAlgorithm;
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
                        var distance = dijsktraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(playerPositions));
                        return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                    }
                case "Pinky":
                    {
                        var newPlayerPosition = new KeyValuePair<int, int>(playerPositions.Key, playerPositions.Value + 2);
                        var distance = dijsktraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(newPlayerPosition));
                        return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                    }
                case "Inky":
                    {
                        var newPlayerPosition = new KeyValuePair<int, int>(playerPositions.Key, playerPositions.Value - 2);

                        var distance = dijsktraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(newPlayerPosition));
                        return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                    }
                case "Clyde":
                    {
                        if (board.GhostSeesThePlayer(ghostName))
                        {
                            var nextMove = ghostFleeAlgorithm.Flee(ghost, player);
                            return PositionConverter.ConvertPositionsFromString(nextMove.Value);
                        }
                        else
                        {
                            var distance = dijsktraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(playerPositions));
                            return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                        }
                    }
                default:
                    {
                        var distance = dijsktraAlgorithm.GetShortestPath(PositionConverter.ConvertPositionsToString(ghostPositions), PositionConverter.ConvertPositionsToString(playerPositions));
                        return PositionConverter.ConvertPositionsFromString(distance[PositionConverter.ConvertPositionsToString(ghostPositions)]);
                    }
            };
        }

    }
}
