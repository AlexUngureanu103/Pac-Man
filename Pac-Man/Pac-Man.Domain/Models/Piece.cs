namespace Pac_Man.Domain.Models
{
    public abstract class Piece
    {
        public bool canMove { get; }
        public bool canBeEaten { get; set; }
        public bool canMoveIn { get; }
        public string Icon { get; set; } = string.Empty;

        protected Piece(bool canMove = false, bool canBeEaten = false, bool canMoveIn = false)
        {
            this.canMove = canMove;
            this.canBeEaten = canBeEaten;
            this.canMoveIn = canMoveIn;
        }
    }
}
