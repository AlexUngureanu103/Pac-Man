using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Business
{
    public class InputManager
    {
        public event Action<char> OnKeyPressed;

        public void HandleKeyPressed(char key)
        {
            OnKeyPressed?.Invoke(key);
        }
    }
}
