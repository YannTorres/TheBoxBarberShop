using TheBoxBarberShop.Domain.Entities;

namespace TheBoxBarberShop.Domain.Security.Tokens;

public interface IAcessTokenGenerator
{
    public string Generate(User user);
}
