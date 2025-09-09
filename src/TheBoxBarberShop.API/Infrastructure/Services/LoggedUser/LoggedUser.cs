using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TheBoxBarberShop.Domain.Entities;
using TheBoxBarberShop.Domain.Security.Tokens;
using TheBoxBarberShop.Domain.Services.LoggedUser;
using TheBoxBarberShop.Infrastructure.DataAcess;

namespace TheBoxBarberShop.Infrastructure.Services.LoggedUser;

internal class LoggedUser : ILoggedUser
{
    private readonly TheBoxBarberShopDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;
    public LoggedUser(TheBoxBarberShopDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }
    public async Task<User> Get()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type.Equals(ClaimTypes.Sid)).Value;

        return await _dbContext
            .Users
            .AsNoTracking()
            .FirstAsync(users => users.Id.Equals(Guid.Parse(identifier)));
    }

}

