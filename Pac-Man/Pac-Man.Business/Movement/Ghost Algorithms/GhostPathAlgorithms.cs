namespace Pac_Man.Business.Movement.Ghost_Algorithms
{
    public class GhostPathAlgorithms
    {
        private DijkstraAlgorithm dijsktraAlgorithm;

        public GhostPathAlgorithms(DijkstraAlgorithm dijkstraAlgorithm)
        {
            dijsktraAlgorithm = dijkstraAlgorithm;
        }

        public Dictionary<string, string> MainGhostMovements(MoveablesContainer ghost, MoveablesContainer player)
        {
            var ghostPositions = ghost.position;
            var playerPositions = player.position;
            var distances = dijsktraAlgorithm.GetShortestPath($"({ghostPositions.Key}, {ghostPositions.Value})", $"({playerPositions.Key}, {playerPositions.Value})");

            return distances;
        }

    }
}
