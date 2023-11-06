namespace Pac_Man.Domain
{
    public class Empty : Piece
    {
        public bool canMove { get => false; }
        public bool canBeEaten { get => false; }
        public bool canMoveIn { get => true; }
    }
}