using TheBoxBarberShop.Application.UseCases.Users.Register;

namespace TheBoxBarberShop.Application;

public static class DependencyInjectionAplication
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
}
