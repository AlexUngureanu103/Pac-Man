using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    internal class Wall : IPiece
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
            return false;
        }

        public string icon()
        {
            throw new NotImplementedException();
        }
    }
}
