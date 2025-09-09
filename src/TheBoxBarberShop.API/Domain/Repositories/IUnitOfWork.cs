namespace TheBoxBarberShop.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}
