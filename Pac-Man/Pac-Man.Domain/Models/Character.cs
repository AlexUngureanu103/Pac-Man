namespace Pac_Man.Domain.Models
{
    public class Character : Piece
    {
        private short lifes = 3;
        public Character() : base(canMove: true, canMoveIn: true)
        {
        }

        public override string ToString()
        {
            return " P ";
        }

        public bool CanMove(Piece piece)
        {
            if (piece is Empty)
            {
                return true;
            }

            if (piece is Food)
            {
                return true;
            }

            if (piece is Ghost)
            {
                lifes--;
                return true;
            }

            //remains the wall
            return false;
        }
    }
}
