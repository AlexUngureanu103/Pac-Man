using Pac_Man.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Business
{
    internal class MoveablesContainer
    {
        public Piece piece { get; set; }
        public KeyValuePair<int, int> position { get; set; }

        public MoveablesContainer(Piece piece) 
        {
            this.piece = piece;
        }
    }
}
