using HltvParser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models
{
	public interface IPlayerStatisticService
	{
		IEnumerable<Player> players { get; set; }
		IEnumerable<PlayersGear> playersGear { get; set; }

		IEnumerable<Player> GetPlayers();
		IEnumerable<PlayersGear> GetPlayersGear();
	}
}