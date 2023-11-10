using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView.Exceptions
{
    public class StripServiceClientException : Exception
    {
        public StripServiceClientException(string? message) : base(message)
        {
        }

        public StripServiceClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
