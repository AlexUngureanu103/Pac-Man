namespace Pac_Man.Business.GraphRepresentation
{
    public class Node
    {
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsGhost { get; set; }
        public bool IsPacMan { get; set; }

        public Node(int rowPosition, int columnPosition, bool isOccupied = false, bool isGhost = false, bool isPacMan = false)
        {
            if (rowPosition < 0 || columnPosition < 0)
                throw new ArgumentException("Row and column position cannot be negative.");

            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
            IsOccupied = isOccupied;
            IsGhost = isGhost;
            IsPacMan = isPacMan;
        }

        public Node(MoveablesContainer moveablesContainer, bool isGhost = false, bool isPacMan = false)
        {
            if (moveablesContainer == null)
                throw new ArgumentNullException("Moveables container cannot be null.");

            RowPosition = moveablesContainer.position.Key;
            ColumnPosition = moveablesContainer.position.Value;
            IsOccupied = true;
            IsGhost = isGhost;
            IsPacMan = isPacMan;
        }

        public override string ToString()
        {
            return $"({RowPosition}, {ColumnPosition})";
        }
    }
}
