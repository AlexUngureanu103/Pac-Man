namespace Pac_Man.Business.GraphRepresentation
{
    public interface IGraph
    {
        IGameCharacters GameCharacters { get; set; }
        Dictionary<string, Node> Nodes { get; set; }
        List<NodeConnection> NodeConnections { get; set; }
        Dictionary<Node, List<NodeConnection>> AdjacencyList { get; set; }

        void PrintAdjacencyList();
        void GraphRestart(IGameCharacters gameCharactersInitialPos);

    }
}
