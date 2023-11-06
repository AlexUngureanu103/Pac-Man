using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Domain
{
    public abstract class Piece
    {
        bool canMove { get; }
        bool canBeEaten { get; }
        bool canMoveIn { get; }
        private string icon { get; set; }
        public string Icon
        {
            get => icon;
            set => icon = value;
        }
    }
}
