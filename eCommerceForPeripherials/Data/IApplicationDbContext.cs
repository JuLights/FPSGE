using eCommerceForPeripherials.Models;
using eCommerceForPeripherials.Models.Admin;
using HltvParser;
using Microsoft.EntityFrameworkCore;

namespace eCommerceForPeripherials.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Item> Items { get; set; }
        DbSet<LastItemIds> LastItemIds { get; set; }
        DbSet<Player> Player { get; set; }
        DbSet<PlayersGear> PlayersGear { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<ProductsGEL> productsGELs { get; set; }
    }
}