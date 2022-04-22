using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HltvParser;
using eCommerceForPeripherials.Models.Admin;
using eCommerceForPeripherials.Services;
using System.Threading;

namespace eCommerceForPeripherials.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Player> Player { get; set; }

        public DbSet<PlayersGear> PlayersGear { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<LastItemIds> LastItemIds { get; set; }
        public DbSet<ProductsGEL> productsGELs { get; set; }
        public DbSet<eCommerceForPeripherials.Models.Mouse> Mouse { get; set; }


        //public sealed override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    return this.SaveChangesAsync(cancellationToken);
        //}

        //// This method has the `async` modifier, so `await` can be used:
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        //public Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //void IApplicationDbContext.SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
