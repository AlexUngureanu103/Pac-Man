using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    public class Food : Piece
    {
        public bool canMove { get => false; }
        public bool canBeEaten { get => true; }
        public bool canMoveIn { get => true; }
    }
}
