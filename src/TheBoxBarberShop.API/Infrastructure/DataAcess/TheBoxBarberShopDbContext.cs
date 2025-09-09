using Microsoft.EntityFrameworkCore;
using TheBoxBarberShop.Domain.Entities;

namespace TheBoxBarberShop.Infrastructure.DataAcess;

public class TheBoxBarberShopDbContext : DbContext
{
    public TheBoxBarberShopDbContext(DbContextOptions<TheBoxBarberShopDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
