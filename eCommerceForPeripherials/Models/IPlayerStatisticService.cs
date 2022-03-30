using HltvParser;
using System.Collections.Generic;

namespace eCommerceForPeripherials.Models
{
	public interface IPlayerStatisticService
	{
		IEnumerable<Player> players { get; set; }

		void GetPlayers();
	}
}