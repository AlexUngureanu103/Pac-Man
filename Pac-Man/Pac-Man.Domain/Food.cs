namespace Pac_Man.Domain
{
    public class Food : Piece
    {
        public Food() : base(canBeEaten: true, canMoveIn: true)
        {
        }
    }
}
