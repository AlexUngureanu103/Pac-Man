using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    internal interface IPiece
    {
        public bool canMove();
        public bool canBeEatan();
        public bool canMoveIn();
        public string icon();
    }
}
