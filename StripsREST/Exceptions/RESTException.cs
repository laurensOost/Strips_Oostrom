namespace StripsREST.Exceptions;

public class RESTException : Exception
{
    public RESTException(string? message) : base(message)
    {
    }

    public RESTException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    
}