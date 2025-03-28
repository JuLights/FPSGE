﻿using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HltvParser;
using eCommerceForPeripherials.Models.Admin;
using eCommerceForPeripherials.Services;

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
        public async Task<int> SaveChangesAsync()
        {
            var result = await this.SaveChangesAsync();
            return result;
        }
    }
}
