namespace Pac_Man.Business.GraphRepresentation
{
    public class NodeConnection
    {
        public Node FirstNode { get; set; }
        public Node SecondNode { get; set; }

        public NodeConnection(Node firstNode, Node secondNode)
        {
            if (firstNode == null || secondNode == null)
                throw new ArgumentNullException("Nodes cannot be null.");

            FirstNode = firstNode;
            SecondNode = secondNode;
        }

        public override string ToString()
        {
            return "First node: " + FirstNode.ToString() + " Second node: " + SecondNode.ToString() + Environment.NewLine;
        }
    }
}
