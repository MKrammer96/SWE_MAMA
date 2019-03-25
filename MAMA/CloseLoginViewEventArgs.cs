using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class CloseLoginViewEventArgs : EventArgs
    {
        public bool Loginsuccessful { get; private set; }

        public CloseLoginViewEventArgs(bool loginsuccessfull)
        {
            Loginsuccessful = loginsuccessfull;
        }
    }
}
