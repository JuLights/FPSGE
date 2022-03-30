using HltvParser;
using System.Collections.Generic;

namespace eCommerceForPeripherials.Models
{
	public interface IPlayerStatisticService
	{
		IEnumerable<Player> players { get; set; }
		IEnumerable<PlayersGear> playersGear { get; set; }

		void GetPlayers();
		void GetPlayersGear();
	}
}