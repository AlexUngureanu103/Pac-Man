using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    internal class Character : IPiece
    {
        public bool canMove { get => true; }
        public bool canBeEaten { get => false; }
        public bool canMoveIn { get => false; }
        public string icon { get ; set; } => string.Empty;
    }
}
