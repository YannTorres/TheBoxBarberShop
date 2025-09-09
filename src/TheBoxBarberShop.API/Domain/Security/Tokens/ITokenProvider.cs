namespace TheBoxBarberShop.Domain.Security.Tokens;

public interface ITokenProvider
{
    string TokenOnRequest();
}
