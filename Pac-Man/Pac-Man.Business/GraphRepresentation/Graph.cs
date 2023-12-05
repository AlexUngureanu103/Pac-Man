using Pac_Man.Domain.Models;

namespace Pac_Man.Business.GraphRepresentation
{
    public class Graph : IGraph
    {
        public IGameCharacters GameCharacters { get; set; }

        public Dictionary<string, Node> Nodes { get; set; } = new();
        public List<NodeConnection> NodeConnections { get; set; } = new List<NodeConnection>();
        public Dictionary<Node, List<NodeConnection>> AdjacencyList { get; set; } = new Dictionary<Node, List<NodeConnection>>();

        public Graph(IBoard boardConfiguration, IGameCharacters gameCharacters)
        {
            GameCharacters = gameCharacters;

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

        private void CreateNodesBasedOnBoardConfiguration(IBoard boardConfiguration)
        {
            for (int i = 0; i < boardConfiguration.Rows; i++)
            {
                for (int j = 0; j < boardConfiguration.Columns; j++)
                {
                    if (boardConfiguration[i, j] is not Wall)
                    {
                        var isGhost = boardConfiguration[i, j] is Ghost;
                        var isPacMan = boardConfiguration[i, j] is Character;

                        var node = new Node(i, j, isGhost || isPacMan, isGhost, isPacMan);
                        Nodes.Add(node.ToString(), node);
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
                    var nodeI = Nodes.ElementAt(i).Value;
                    var nodeJ = Nodes.ElementAt(j).Value;
                    if (nodeI.RowPosition == nodeJ.RowPosition && Math.Abs(nodeI.ColumnPosition - nodeJ.ColumnPosition) == 1)
                    {
                        var nodeConnection = new NodeConnection(nodeI, nodeJ);
                        var nodeConnectionReverse = new NodeConnection(nodeJ, nodeI);
                        NodeConnections.Add(nodeConnection);
                        AddToAdjacencyList(nodeI, nodeConnection);
                        AddToAdjacencyList(nodeJ, nodeConnectionReverse);
                    }
                    else if (nodeI.ColumnPosition == nodeJ.ColumnPosition && Math.Abs(nodeI.RowPosition - nodeJ.RowPosition) == 1)
                    {
                        var nodeConnection = new NodeConnection(nodeI, nodeJ);
                        var nodeConnectionReverse = new NodeConnection(nodeJ, nodeI);
                        NodeConnections.Add(nodeConnection);
                        AddToAdjacencyList(nodeI, nodeConnection);
                        AddToAdjacencyList(nodeJ, nodeConnectionReverse);
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
