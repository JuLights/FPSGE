using HltvParser;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Data
{
    public interface IAppDbContextService
    {
        Task<string> WriteDataToPlayersAsync(Player players);
    }
}