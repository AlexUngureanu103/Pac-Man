namespace Pac_Man.Domain.Models
{
    public class Food : Piece
    {
        public Food() : base(canBeEaten: true, canMoveIn: true)
        {
        }

        public override string ToString()
        {
            return ".  ";
        }
    }
}
