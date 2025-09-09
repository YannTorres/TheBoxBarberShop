using Microsoft.EntityFrameworkCore;
using TheBoxBarberShop.Domain.Repositories;
using TheBoxBarberShop.Domain.Security.Cryptography;
using TheBoxBarberShop.Domain.Security.Tokens;
using TheBoxBarberShop.Domain.Services.LoggedUser;
using TheBoxBarberShop.Infrastructure.DataAcess;
using TheBoxBarberShop.Infrastructure.Security.Tokens;
using TheBoxBarberShop.Infrastructure.Services.LoggedUser;

namespace TheBoxBarberShop.Infrastructure;

public static class DependencyInjectionInfrastructure
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptograpy.BCrypt>();
        services.AddScoped<ILoggedUser, LoggedUser>();

        AddRepositories(services);
        AddToken(services, configuration);
        AddDbcContext(services, configuration);
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(signingKey!, expirationTimeMinutes));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }


    private static void AddDbcContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<TheBoxBarberShopDbContext>(config => config.UseSqlServer(connectionString));
    }
}
