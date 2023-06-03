using System.Runtime.Serialization;

namespace SerializationLib.Models.Exceptions;

public class LibraryException : Exception
{
    public LibraryException()
    {

    }
    public LibraryException(String message) : base(message)
    {

    }
    public LibraryException(String message, Exception ex) : base(message)
    {

    }
    protected LibraryException(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}