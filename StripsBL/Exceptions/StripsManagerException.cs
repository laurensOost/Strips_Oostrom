using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Exceptions
{
    public class StripsManagerException : Exception
    {
        public StripsManagerException(string? message) : base(message)
        {
        }

        public StripsManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
