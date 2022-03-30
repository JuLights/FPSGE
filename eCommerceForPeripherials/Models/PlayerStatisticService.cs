using HltvParser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models
{
	public class PlayerStatisticService : IPlayerStatisticService
	{
		//public static PlayerStatisticService _playerStatisticService = new PlayerStatisticService();
		public IEnumerable<Player> players { get; set; }
		public IEnumerable<PlayersGear> playersGear { get; set; }
		public PlayerStatisticService()
		{
			GetPlayers();
			GetPlayersGear();
		}

		public async void GetPlayers()
		{
			players = await HltvParser.HltvParser.GetTopPlayers();
		}

		public async void GetPlayersGear()
        {
			playersGear = await HltvParser.HltvParser.GetPlayersGearAsync();
		}

	}
}
