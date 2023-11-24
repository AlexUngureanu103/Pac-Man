using Pac_Man.Business.GraphRepresentation;

public class DijkstraAlgorithm
{
    private Graph graph;

    public DijkstraAlgorithm(Graph graph)
    {
        this.graph = graph;
    }

    public Dictionary<string, string> Execute(string startNode, string endNode, int maxWeight)
    {
        var adjList = graph.AdjacencyList;
        var nodes = graph.Nodes;
        var arches = graph.NodeConnections;

        var distances = new Dictionary<string, int>();
        var previous = new Dictionary<string, string>();
        var visited = new Dictionary<string, bool>();
        var queue = new PriorityQueue<string, int>();

        foreach (var node in nodes)
        {
            distances.Add(node.Value.ToString(), int.MaxValue);
            previous.Add(node.Value.ToString(), null);
            visited.Add(node.Value.ToString(), false);
        }

        distances[startNode] = 0;
        queue.Enqueue(startNode, 0);
        while(!queue.Count.Equals(0))
        {
            var currentNode = queue.Dequeue();
            if (visited[currentNode])
            {
                continue;
            }
            if(currentNode == endNode)
            {
                break;
            }
            visited[currentNode] = true;

            foreach (var neighbour in adjList[graph.Nodes[currentNode]])
            {
                if (!visited[neighbour.SecondNode.ToString()])
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
            reconstructedPath.Add(path[currentNode], currentNode );
            currentNode = path[currentNode];
        }

        return reconstructedPath;
    }
}
