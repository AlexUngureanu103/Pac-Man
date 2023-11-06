namespace Pac_Man.Domain
{
    public abstract class Piece
    {
        public bool canMove { get; set; }
        public bool canBeEaten { get; set; }
        public bool canMoveIn { get; set; }
        public string Icon { get; set; }
    }
}
