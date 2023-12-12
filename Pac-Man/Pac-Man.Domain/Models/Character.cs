namespace Pac_Man.Domain.Models
{
    public class Character : Piece
    {
        public Character() : base(canMove: true, canMoveIn: true)
        {
        }

        public override string ToString()
        {
            return "P  ";
        }
    }
}
