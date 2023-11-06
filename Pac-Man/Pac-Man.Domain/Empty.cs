namespace Pac_Man.Domain
{
    public class Empty : IPiece
    {
        public bool canBeEatan()
        {
            return false;
        }

        public bool canMove()
        {
            return false;
        }

        public bool canMoveIn()
        {
            return true;
        }

        public string icon()
        {
            throw new NotImplementedException();
        }
    }
}