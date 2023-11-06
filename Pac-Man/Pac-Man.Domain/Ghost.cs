using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    internal class Ghost : IPiece
    {
        public bool canBeEatan()
        {
            return false;
        }

        public bool canMove()
        {
            return true;
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
