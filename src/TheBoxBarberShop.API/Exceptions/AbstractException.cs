namespace TheBoxBarberShop.Exceptions;

public abstract class AbstractException : Exception
{
    protected AbstractException() { }
    protected AbstractException(string message) : base(message) { }

    public abstract List<string> GetErrors();
}
