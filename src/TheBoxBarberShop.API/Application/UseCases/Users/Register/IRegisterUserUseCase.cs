using TheBoxBarberShop.Communication.Request.Users;
using TheBoxBarberShop.Communication.Response.Users;

namespace TheBoxBarberShop.Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisterUserJson> Execute(RequestRegisteredUserJson request);
}
