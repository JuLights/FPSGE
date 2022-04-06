using eCommerceForPeripherials.Data;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models.Helpers
{
    public class GearLinkHelper
    {
        //forHeadset
        public async Task<string> CheckAndAddHeadsetInPros(Item item, ApplicationDbContext _db, string operation)
        {
            var playersGear = _db.PlayersGear.ToList();
            //var ourItems = _db.Items.ToList();
            int count = 0;
            foreach (var gear in playersGear)
            {
                if (gear.Headset.ToLower() == item.Name.ToLower())
                {
                    if (operation == "add")
                    {
                        //var lastAddedItem = ourItems.LastOrDefault();
                        var lastAddedItemId = _db.LastItemIds.ToList().LastOrDefault().LastItemId;
                        var link = $"https://fps.ge/shop/details/{lastAddedItemId}";
                        gear.HeadsetLink = link;
                        _db.PlayersGear.Update(gear);
                        await _db.SaveChangesAsync();
                        count++;
                    }
                    else
                    {
                        var link = $"https://fps.ge/shop/details/{item.Id}";
                        gear.HeadsetLink = link;
                        _db.PlayersGear.Update(gear);
                        await _db.SaveChangesAsync();
                        count++;
                    }
                    
                }
            }

            return $"Headset added, also Affected {count} Pro's Headset";

        }
        //forKeyboard
        public async Task<string> CheckAndAddKeyboardInPros(Item item, ApplicationDbContext _db, string operation)
        {
            var playersGear = _db.PlayersGear.ToList();
            var ourItems = _db.Items.ToList();
            int count = 0;
            foreach (var gear in playersGear)
            {
                if (gear.KeyBoard.ToLower() == item.Name.ToLower())
                {
                    if(operation == "add")
                    {
                        var lastAddedItemId = _db.LastItemIds.ToList().LastOrDefault().LastItemId;
                        var link = $"https://fps.ge/shop/details/{lastAddedItemId}"; // memgoni gasworda(ak araswori id gamodis tu delete gaaketes itemis
                        gear.KeyBoardLink = link;
                        _db.PlayersGear.Update(gear);
                        await _db.SaveChangesAsync();
                        count++;
                    }
                    else
                    {
                        var link = $"https://fps.ge/shop/details/{item.Id}";
                        gear.KeyBoardLink = link;
                        _db.PlayersGear.Update(gear);
                        await _db.SaveChangesAsync();
                        count++;
                    }
                    
                }
            }

            return $"Keyboard added, also Affected {count} Pro's Keyboard";

        }

        //forMouse
        public async Task<string> CheckAndAddMouseInPros(Item item, ApplicationDbContext _db, string operation)
        {
            var playersGear = _db.PlayersGear.ToList();
            var ourItems = _db.Items.ToList();
            int count = 0;

            foreach (var gear in playersGear)
            {
                if (gear.Mouse.ToLower() == item.Name.ToLower())
                {
                    if(operation == "add")
                    {
                        var lastAddedItemId = _db.LastItemIds.ToList().LastOrDefault().LastItemId;
                        var link = $"https://fps.ge/shop/details/{lastAddedItemId}";
                        gear.MouseLink = link;
                        _db.PlayersGear.Update(gear);
                        await _db.SaveChangesAsync();
                        count++;
                    }
                    else //Edit item
                    {
                        var link = $"https://fps.ge/shop/details/{item.Id}";
                        gear.MouseLink = link;
                        _db.PlayersGear.Update(gear);
                        await _db.SaveChangesAsync();
                        count++;
                    }
                }
            }

            return $"Mouse added, also Affected {count} Pro's Mouse";
        }
    }
}
