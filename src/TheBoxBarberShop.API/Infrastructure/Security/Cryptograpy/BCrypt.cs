using TheBoxBarberShop.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace TheBoxBarberShop.Infrastructure.Security.Cryptograpy;

public class BCrypt : IPasswordEncripter
{
    public string Encript(string password)
    {
        string passwordHash = BC.HashPassword(password);


        return passwordHash;
    }

    public bool Verify(string password, string passwordHash)
    {
        return BC.Verify(password, passwordHash);
    }
}
