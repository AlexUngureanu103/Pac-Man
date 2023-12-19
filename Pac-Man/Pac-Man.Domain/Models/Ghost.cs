namespace Pac_Man.Domain.Models
{
    public class Ghost : Piece
    {
        public Ghost() : base(canMove: true, canMoveIn: true)
        {
        }

        public override string ToString()
        {
            //return " G ";
            return Icon.FirstOrDefault() + "  ";
        }
    }
}
