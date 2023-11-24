using Pac_Man.Business.GraphRepresentation;

namespace Pac_Man.Business.Movement.Ghost_Algorithms
{
    public class GhostFleeAlgorithm
    {
        private Graph graph;

        public GhostFleeAlgorithm(Graph graph)
        {
            this.graph = graph;
        }

        public KeyValuePair<string, string> Flee(MoveablesContainer ghost, MoveablesContainer player)
        {
            var ghostPositions = ghost.position;
            var playerPositions = player.position;

            var safestPosition = new KeyValuePair<string, string>("", "");
            var maxDistance = int.MinValue;

            foreach (var neighbour in graph.AdjacencyList[graph.Nodes[$"({ghostPositions.Key}, {ghostPositions.Value})"]])
            {
                if (neighbour.SecondNode.IsOccupied)
                {
                    continue;
                }

                var distance = Math.Abs(neighbour.SecondNode.RowPosition - playerPositions.Key) + Math.Abs(neighbour.SecondNode.ColumnPosition - playerPositions.Value);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    safestPosition = new KeyValuePair<string, string>($"({neighbour.SecondNode.RowPosition}, {neighbour.SecondNode.ColumnPosition})", $"({neighbour.FirstNode.RowPosition}, {neighbour.FirstNode.ColumnPosition})");
                }
                else if (distance == maxDistance)
                {
                    var random = new Random();
                    var randomValue = random.Next(0, 2);
                    if (randomValue == 0)
                    {
                        maxDistance = distance;
                        safestPosition = new KeyValuePair<string, string>($"({neighbour.SecondNode.RowPosition}, {neighbour.SecondNode.ColumnPosition})", $"({neighbour.FirstNode.RowPosition}, {neighbour.FirstNode.ColumnPosition})");
                    }
                }
            }

            return safestPosition;
        }
    }
}
