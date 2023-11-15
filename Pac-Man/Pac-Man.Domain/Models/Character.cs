namespace Pac_Man.Domain.Models
{
    public class Character : Piece
    {
        public KeyValuePair<int, int> position;
        public Character() : base(canMove: true, canMoveIn: true)
        {
        }

        public override string ToString()
        {
            return " P ";
        }
    }
}
