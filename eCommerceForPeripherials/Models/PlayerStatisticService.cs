using eCommerceForPeripherials.Data;
using HltvParser;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models
{
	public class PlayerStatisticService : IPlayerStatisticService
	{
		public IEnumerable<Player> players { get; set; }
		public IEnumerable<PlayersGear> playersGear { get; set; }
		private readonly ApplicationDbContext _db;
		public PlayerStatisticService(ApplicationDbContext db)
		{
			_db = db;
		}

		public IEnumerable<Player> GetPlayers()
        {
			players = _db.Player;
			return players;
		} 

		public IEnumerable<PlayersGear> GetPlayersGear()
        {
			playersGear = _db.PlayersGear;
			return playersGear;
		}

	}
}
