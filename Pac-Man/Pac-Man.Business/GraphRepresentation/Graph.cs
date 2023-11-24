using Pac_Man.Domain.Models;

namespace Pac_Man.Business.GraphRepresentation
{
    //TO DO : generate the graph based on the board configuration
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<NodeConnection> NodeConnections { get; set; } = new List<NodeConnection>();
        public Dictionary<Node, List<NodeConnection>> AdjacencyList { get; set; } = new Dictionary<Node, List<NodeConnection>>();

        public Graph(List<Node> nodes, List<NodeConnection> nodeConnections)
        {
            if (nodes == null || nodeConnections == null)
                throw new ArgumentNullException("Nodes and node connections cannot be null.");

            Nodes = nodes;
            NodeConnections = nodeConnections;
        }

        public Graph(Board boardConfiguration)
        {
            CreateNodesBasedOnBoardConfiguration(boardConfiguration);
            GenerateNodeConnectionsBasedOnNodesPositions();
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Adjacency list: ");

            foreach (var node in AdjacencyList)
            {
                Console.Write($"Node ({node.Key.RowPosition}, {node.Key.ColumnPosition}) is connected to: " + Environment.NewLine);
                foreach (var connection in node.Value)
                {
                    Console.Write(connection);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        private void CreateNodesBasedOnBoardConfiguration(Board boardConfiguration)
        {
            for (int i = 0; i < boardConfiguration.Rows; i++)
            {
                for (int j = 0; j < boardConfiguration.Columns; j++)
                {
                    if (boardConfiguration[i, j] is not Wall)
                    {
                        var isGhost = boardConfiguration[i, j] is Ghost;
                        var isPacMan = boardConfiguration[i, j] is Character;

                        Nodes.Add(new Node(i, j, isGhost || isPacMan, isGhost, isPacMan));
                    }
                }
            }
        }

        private void GenerateNodeConnectionsBasedOnNodesPositions()
        {
            for (int i = 0; i < Nodes.Count - 1; i++)
            {
                for (int j = i + 1; j < Nodes.Count; j++)
                {
                    if (Nodes[i].RowPosition == Nodes[j].RowPosition && Math.Abs(Nodes[i].ColumnPosition - Nodes[j].ColumnPosition) == 1)
                    {
                        var nodeConnection = new NodeConnection(Nodes[i], Nodes[j]);
                        NodeConnections.Add(nodeConnection);
                        AddToAdjacencyList(Nodes[i], nodeConnection);
                        AddToAdjacencyList(Nodes[j], nodeConnection);
                    }
                    else if (Nodes[i].ColumnPosition == Nodes[j].ColumnPosition && Math.Abs(Nodes[i].RowPosition - Nodes[j].RowPosition) == 1)
                    {
                        var nodeConnection = new NodeConnection(Nodes[i], Nodes[j]);
                        NodeConnections.Add(nodeConnection);
                        AddToAdjacencyList(Nodes[i], nodeConnection);
                        AddToAdjacencyList(Nodes[j], nodeConnection);
                    }
                }
            }
        }

        private void AddToAdjacencyList(Node node, NodeConnection nodeConnection)
        {
            if (AdjacencyList.ContainsKey(node))
            {
                AdjacencyList[node].Add(nodeConnection);
            }
            else
            {
                AdjacencyList[node] = new List<NodeConnection> { nodeConnection };
            }
        }

    }
}
