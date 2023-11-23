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
        var adjacencyList = graph.AdjacencyList;
        var distances = new Dictionary<string, int>();
        var buckets = new Queue<string>[maxWeight + 1];
        var path = new Dictionary<string, string>();

        for (int i = 0; i <= maxWeight; i++)
        {
            buckets[i] = new Queue<string>();
        }

        foreach (var node in adjacencyList.Keys)
        {
            distances[node.ToString()] = maxWeight;
            buckets[maxWeight].Enqueue(node.ToString());
        }

        distances[startNode] = 0;
        buckets[0].Enqueue(startNode);

        for (int i = 0; i <= maxWeight; i++)
        {
            while (buckets[i].Count != 0)
            {
                var currentNode = buckets[i].Dequeue();
                var currentDistance = distances[currentNode];

                if (currentNode == endNode)
                {
                    return ReconstructPath(path, startNode, endNode);
                }
                foreach (var neighbour in adjacencyList[graph.Nodes[currentNode]])
                {
                    var oldDistance = distances[neighbour.SecondNode.ToString()];
                    var newDistance = currentDistance + 1;


                    if (newDistance < oldDistance)
                    {
                        distances[neighbour.SecondNode.ToString()] = newDistance;
                        buckets[oldDistance].Dequeue();
                        buckets[newDistance].Enqueue(neighbour.SecondNode.ToString());

                        path[currentNode] = neighbour.SecondNode.ToString();
                    }
                }
            }
        }

        return ReconstructPath(path, startNode, endNode);
    }

    private Dictionary<string, string> ReconstructPath(Dictionary<string, string> path, string startNode, string endNode)
    {
        var reconstructedPath = new Dictionary<string, string>();

        var currentNode = endNode;

        while (currentNode != startNode)
        {
            reconstructedPath.Add(currentNode, path[currentNode]);
            currentNode = path[currentNode];
        }

        return reconstructedPath;
    }
}
