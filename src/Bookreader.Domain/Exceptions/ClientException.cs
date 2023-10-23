using System.Net;

namespace Bookreader.Domain.Exceptions;

public abstract class ClientException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    
    public abstract string TitleMessage { get; protected set; }
}