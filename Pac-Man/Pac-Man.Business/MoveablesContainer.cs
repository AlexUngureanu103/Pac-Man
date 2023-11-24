using Pac_Man.Domain.Models;

namespace Pac_Man.Business
{
    public class MoveablesContainer
    {
        public Piece piece { get; set; }
        public KeyValuePair<int, int> position { get; set; }

        public MoveablesContainer(Piece piece)
        {
            this.piece = piece;
        }
    }
}
