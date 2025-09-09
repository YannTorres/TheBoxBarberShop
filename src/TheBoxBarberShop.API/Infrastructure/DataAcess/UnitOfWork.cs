using TheBoxBarberShop.Domain.Repositories;

namespace TheBoxBarberShop.Infrastructure.DataAcess;

public class UnitOfWork : IUnitOfWork
{
    private readonly TheBoxBarberShopDbContext _dbcontext;

    public UnitOfWork(TheBoxBarberShopDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    public async Task Commit()
    {
        await _dbcontext.SaveChangesAsync();
    }
}
