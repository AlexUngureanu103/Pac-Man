using Pac_Man.Business.GraphRepresentation;

namespace Pac_Man.Business.Movement
{
    public class DijkstraAlgorithm : IDijkstraAlgorithm
    {
        private readonly IGraph graph;

        public DijkstraAlgorithm(IGraph graph)
        {
            this.graph = graph;
        }
        /// <summary>
        /// Get the shortest path between two nodes. The algorithm is based on Dijkstra's algorithm.
        /// The parameters are the .ToString() methods of the nodes, which are in the format: "(row, column)".
        /// </summary>
        /// <param name="startNode"> The start node for the algorithm</param>
        /// <param name="endNode"> The destination node for the algorithm</param>
        /// <returns></returns>
        public Dictionary<string, string> GetShortestPath(string startNode, string endNode)
        {
            var adjList = graph.AdjacencyList;
            var nodes = graph.Nodes;

            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var visited = new Dictionary<string, bool>();
            var queue = new PriorityQueue<string, int>();

            foreach (var node in nodes)
            {
                distances.Add(node.Value.ToString(), int.MaxValue);
                previous.Add(node.Value.ToString(), string.Empty);
                visited.Add(node.Value.ToString(), false);
            }
            distances[startNode] = 0;
            queue.Enqueue(startNode, 0);

            while (!queue.Count.Equals(0))
            {
                var currentNode = queue.Dequeue();
                if (visited[currentNode])
                {
                    continue;
                }
                if (currentNode == endNode)
                {
                    break;
                }
                visited[currentNode] = true;

                foreach (var neighbour in adjList[graph.Nodes[currentNode]])
                {
                    // A Ghost cannot go through another Ghost
                    if (!visited[neighbour.SecondNode.ToString()] && !neighbour.SecondNode.IsGhost)
                    {
                        var newDistance = distances[currentNode] + 1;
                        if (newDistance < distances[neighbour.SecondNode.ToString()])
                        {
                            distances[neighbour.SecondNode.ToString()] = newDistance;
                            previous[neighbour.SecondNode.ToString()] = currentNode;
                            queue.Enqueue(neighbour.SecondNode.ToString(), newDistance);
                        }
                    }
                }
            }
            if (distances[endNode] == int.MaxValue)
            {
                return new Dictionary<string, string>();
            }

            return ReconstructPath(previous, startNode, endNode);
        }

        private Dictionary<string, string> ReconstructPath(Dictionary<string, string> path, string startNode, string endNode)
        {
            var reconstructedPath = new Dictionary<string, string>();

            var currentNode = endNode;

            while (currentNode != startNode)
            {
                reconstructedPath.Add(path[currentNode], currentNode);
                currentNode = path[currentNode];
            }

            return reconstructedPath;
        }
    }
}