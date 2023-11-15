namespace Pac_Man.Domain.Models
{
    public class Ghost : Piece
    {
        public KeyValuePair<int, int> position;

        public Ghost() : base(canMove: true)
        {
        }

        public override string ToString()
        {
            return " G ";
        }
    }
}
