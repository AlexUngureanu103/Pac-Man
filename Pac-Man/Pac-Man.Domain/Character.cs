using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    public class Character : Piece
    {
        public bool canMove { get => true; }
        public bool canBeEaten { get => false; }
        public bool canMoveIn { get => false; }
    }
}
