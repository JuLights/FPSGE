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

        public ProPlayerStatsController(IPlayerStatisticService playerStatisticService, ApplicationDbContext db)
		{
            _playerStatisticService = playerStatisticService;
            _db = db;
        }


        //Pagination 
        //[Route("{id:int}")]
        public async Task<ActionResult<List<Player>>> Index(int Id)
        {
            TempData["ProPlayers"] = "active";
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
            TempData["ProPlayers"] = "active";

            var playersGear = _playerStatisticService.GetPlayersGear();
            if (playersGear == null)
                return NotFound();

            var _playersGear = playersGear.ToList();

            //SetupLinksForProducts(_playersGear, _db.Items.ToList());

            var pageResults = 20f; //20 item per page

            var pageCount = PaginationHelper.GetPageCount(_playersGear, pageResults);
            var PlayersGearPerPage = PaginationHelper.GetRangedData(pageResults, Id, _playersGear);


            TempData["page"] = $"{Id}";
            TempData["pageCount"] = $"{pageCount}";

            return View(PlayersGearPerPage);
        }

        public void SetupLinksForProducts(List<PlayersGear> playersGears, List<Item> items)
        {
            List<Item> headsetList = new List<Item>();
            List<Item> keyboardList = new List<Item>();
            List<Item> mouseList = new List<Item>();

            foreach (var item in items)
            {
                if (item.ItemName.ToLower() == "headset")
                {
                    headsetList.Add(item);
                }
                if (item.ItemName.ToLower() == "keyboard")
                {
                    keyboardList.Add(item);
                }
                if (item.ItemName.ToLower() == "mouse")
                {
                    mouseList.Add(item);
                }
            }

            Dictionary<int, string> foundedKeyboardList = new Dictionary<int, string>();

            //Keyboard
            for (int j = 0; j < keyboardList.Count; j++)
            {
                for (int i = 0; i < playersGears.Count; i++)
                {
                    if (keyboardList[j].Name.ToLower() == playersGears[i].KeyBoard.ToLower())
                    {
                        //1 varianti PlayersGear-is tables bazashi mivamato link chvens saitze produqciis
                        string linktoAdd = $"https://fps.ge/shop/details/{keyboardList[j].Id}";
                        foundedKeyboardList.Add(playersGears[i].Id, linktoAdd);
                    }
                }

            }

            foreach (var item in foundedKeyboardList)
            {
                var plg = _db.PlayersGear.Where(x => x.Id == item.Key).FirstOrDefault();
                plg.KeyBoardLink = item.Value;
                //var playerWithLink = (PlayersGear)plg;

                _db.PlayersGear.Update(plg);
                _db.SaveChanges();
            }

        }





    }

}
