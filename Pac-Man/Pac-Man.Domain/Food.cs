using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    internal class Food : IPiece
    {
        public bool canMove { get => false; }
        public bool canBeEaten { get => true; }
        public bool canMoveIn { get => true; }
        public string icon { get => throw new NotImplementedException(); }
    }
}
