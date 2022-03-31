using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HltvParser;
using eCommerceForPeripherials.Models.Admin;

namespace eCommerceForPeripherials.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Player> Player { get; set; }

        public DbSet<PlayersGear> PlayersGear { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
