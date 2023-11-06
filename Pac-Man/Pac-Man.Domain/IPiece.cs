using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    internal interface IPiece
    {
        bool canMove { get; }
        bool canBeEaten { get; }
        bool canMoveIn { get; }
        string icon { get; }
    }
}
