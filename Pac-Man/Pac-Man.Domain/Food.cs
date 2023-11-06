using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    internal class Food : IPiece
    {
        public bool canBeEatan()
        {
            return true;
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
