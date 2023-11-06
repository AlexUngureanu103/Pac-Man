namespace Pac_Man.Domain
{
    public class Empty : IPiece
    {
        public bool canMove { get => false; }
        public bool canBeEaten { get => false; }
        public bool canMoveIn { get => true; }
        public string icon { get => throw new NotImplementedException(); }
    }
}