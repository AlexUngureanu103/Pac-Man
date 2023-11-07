namespace Pac_Man.Domain.Models
{
    public class Character : Piece
    {
        public Character() : base(canMove: true, canMoveIn: true)
        {
        }
    }
}
