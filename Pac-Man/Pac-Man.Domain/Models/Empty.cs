namespace Pac_Man.Domain.Models
{
    public class Empty : Piece
    {
        public Empty() : base(canMoveIn: true)
        {
        }
    }
}