namespace Pac_Man.Business.GraphRepresentation
{
    //TO DO : generate the graph based on the board configuration
    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<NodeConnection> NodeConnections { get; set; }

        public Graph(List<Node> nodes, List<NodeConnection> nodeConnections)
        {
            if (nodes == null || nodeConnections == null)
                throw new ArgumentNullException("Nodes and node connections cannot be null.");

            Nodes = nodes;
            NodeConnections = nodeConnections;
        }

        public Graph(Board boardConfiguration)
        {
            //boardConfiguration.
        }
    }
}
