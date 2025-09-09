namespace TheBoxBarberShop.Exceptions;

public class ValidationException : AbstractException
{
    public ValidationException(List<string> messages)
    {
        _errors = messages;
    }

    private readonly List<string> _errors;

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
