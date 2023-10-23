namespace Bookreader.Domain.Exceptions;

public class VerificationTooManyRequestExeption : TooManyRequestException
{
    public VerificationTooManyRequestExeption()
    {
        TitleMessage = "You tried more than limit!";
    }
}