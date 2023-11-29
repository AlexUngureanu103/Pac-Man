namespace Pac_Man.Business.Movement
{
    public interface IDijkstraAlgorithm
    {
        Dictionary<string, string> GetShortestPath(string startNode, string endNode);
    }
}
