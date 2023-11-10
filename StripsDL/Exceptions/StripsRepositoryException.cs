using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Exceptions
{
    public class StripsRepositoryException : Exception 
    {
        public StripsRepositoryException(string? message) : base(message)
        {
        }

        public StripsRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
