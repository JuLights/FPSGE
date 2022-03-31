using HltvParser;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Data
{
    public class AppDbContextService : IAppDbContextService
    {
        private readonly ApplicationDbContext _context;
        public AppDbContextService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<string> WriteDataToPlayersAsync(Player players)
        {
            await _context.Player.AddAsync(players);
            await _context.SaveChangesAsync();
            return "Added";
        }

    }
}
