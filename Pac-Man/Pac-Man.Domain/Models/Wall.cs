namespace Pac_Man.Domain.Models
{
    public class Wall : Piece
    {
        public Wall() : base()
        {
        }

        public override string ToString()
        {
            return "W  ";
        }
    }
}
