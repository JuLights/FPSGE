using System;
using Microsoft.AspNetCore.Mvc;
using eCommerceForPeripherials.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using HltvParser;
using eCommerceForPeripherials.Data;
using System.Linq;
using eCommerceForPeripherials.Models.Helpers;

namespace eCommerceForPeripherials.Controllers
{
    public class ProPlayerStatsController : Controller
    {
        private IPlayerStatisticService _playerStatisticService;
        private readonly ApplicationDbContext _db;

        //private readonly IAppDbContextService _dbService;
        public ProPlayerStatsController(IPlayerStatisticService playerStatisticService)
		{
            _playerStatisticService = playerStatisticService;
        }


        //Pagination 
        //[Route("{id:int}")]
        public async Task<ActionResult<List<Player>>> Index(int Id)
        {
            var playerStats = _playerStatisticService.GetPlayers();

            if (playerStats == null)
                return NotFound();

            var _playerStats = playerStats.ToList();

            var pageResults = 20f; //20 item per page

            var pageCount = PaginationHelper.GetPageCount(_playerStats, pageResults);
            var PlayersPerPage = PaginationHelper.GetRangedData(pageResults,Id, _playerStats);

            TempData["page"] = $"{Id}";
            TempData["pageCount"] = $"{pageCount}";

            return View(PlayersPerPage);
        }

        //Pagination 
        //[Route("{id:int}")]
        public async Task<IActionResult> PlayersGear(int Id)
        {
            
            var playersGear = _playerStatisticService.GetPlayersGear();
            if (playersGear == null)
                return NotFound();

            var _playersGear = playersGear.ToList();

            var pageResults = 20f; //20 item per page

            var pageCount = PaginationHelper.GetPageCount(_playersGear, pageResults);
            var PlayersGearPerPage = PaginationHelper.GetRangedData(pageResults, Id, _playersGear);


            TempData["page"] = $"{Id}";
            TempData["pageCount"] = $"{pageCount}";

            return View(PlayersGearPerPage);
        }

    }

}
