using Microsoft.AspNetCore.Mvc;
using eCommerceForPeripherials.Models;

namespace eCommerceForPeripherials.Controllers
{
    public class ProPlayerStatsController : Controller
    {
        IPlayerStatisticService _playerStatisticService;
        public ProPlayerStatsController(PlayerStatisticService playerStatisticService)
		{
            _playerStatisticService = playerStatisticService;
        }

        public IActionResult Index()
        {

            return View(_playerStatisticService.players);
        }

        public IActionResult PlayersGear()
        {
            return View(_playerStatisticService.playersGear);
        }

    }
}
