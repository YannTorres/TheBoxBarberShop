using TheBoxBarberShop.Domain.Security.Tokens;

namespace TheBoxBarberShop.Api.Token;

public class HttpContextTokenValue : ITokenProvider
{
    public string TokenOnRequest()
    {
        throw new NotImplementedException();
    }
}
