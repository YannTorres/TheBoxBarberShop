namespace TheBoxBarberShop.Infrastructure.DataAcess.Repositories;

internal class UserRepository
{
    private readonly TheBoxBarberShopDbContext _dbcontext;

    public UserRepository(TheBoxBarberShopDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
}
