using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.)]
        //public int ItemId { get; set; }
        public int ViewCount { get; set; }
        [Display(Name ="ფოტო")]
        public string ItemImageUrl { get; set; }
        [Display(Name = "ნივთი")]
        public string ItemName { get; set; } //mouse, keyboard, headset
        [Display(Name = "მდგომარეობა")]
        public string ItemCondition { get; set; } // axali, axalivit, meoradi
        [Display(Name ="მოდელი")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "აღწერა")]
        public string Description { get; set; }
        [Display(Name = "მწარმოებელი")]
        public string Brand { get; set; }
        [Display(Name = "ConnectionType")]
        public string Connection { get; set; }
        [Display(Name = "კავშირისტიპი")]
        public string Wireless { get; set; }
        [Display(Name = "სიგრძე")]
        public string CableLength { get; set; }
        [Display(Name = "ფასი")]
        public string Price { get; set; }
        [Display(Name = "ფერი")]
        public string Colour { get; set; }
        public string RGB { get; set; }

    }
}
