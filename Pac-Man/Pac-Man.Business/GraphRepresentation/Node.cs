namespace Pac_Man.Business.GraphRepresentation
{
    public class Node
    {
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
        public bool IsOccupied { get; set; }

        public Node(int rowPosition, int columnPosition, bool isOccupied = false)
        {
            if (rowPosition < 0 || columnPosition < 0)
                throw new ArgumentException("Row and column position cannot be negative.");

            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
            IsOccupied = isOccupied;
        }

        public Node(MoveablesContainer moveablesContainer)
        {
            if (moveablesContainer == null)
                throw new ArgumentNullException("Moveables container cannot be null.");

            RowPosition = moveablesContainer.position.Key;
            ColumnPosition = moveablesContainer.position.Value;
            IsOccupied = true;
        }
    }
}
