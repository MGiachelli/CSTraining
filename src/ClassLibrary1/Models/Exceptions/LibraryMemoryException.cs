using System.Runtime.Serialization;

namespace ClassLibrary1.Models.Exceptions;

public class LibraryMemoryException : LibraryException
{
    public LibraryMemoryException()
    {

    }
    public LibraryMemoryException(String message) : base(message)
    {

    }
    public LibraryMemoryException(String message, Exception ex) : base(message)
    {

    }
    protected LibraryMemoryException(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}