using Microsoft.EntityFrameworkCore;
using TheBoxBarberShop.Infrastructure.DataAcess;

namespace TheBoxBarberShop.Infrastructure.Migrations;

public static class DataBaseMigration
{
    public static async Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbcontext = serviceProvider.GetRequiredService<TheBoxBarberShopDbContext>();

        await dbcontext.Database.MigrateAsync();
    }
}
