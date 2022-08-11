using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Exceptions
{
    public class UniqueValueAlreadyUsedException : Exception
    {
        public UniqueValueAlreadyUsedException(string message)
            : base(message)
        {
        }
    }
}
