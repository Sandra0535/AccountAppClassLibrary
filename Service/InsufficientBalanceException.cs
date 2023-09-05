using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppClassLibrary.Service
{
    internal class InsufficientBalanceException:Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
}
