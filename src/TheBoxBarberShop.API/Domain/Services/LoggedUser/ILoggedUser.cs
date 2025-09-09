using TheBoxBarberShop.Domain.Entities;

namespace TheBoxBarberShop.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> Get();
}

