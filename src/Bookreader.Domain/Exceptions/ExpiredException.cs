using System.Net;

namespace Bookreader.Domain.Exceptions.Auth;

public class ExpiredException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = String.Empty;
}