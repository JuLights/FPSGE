﻿using System;
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
        public string ItemImageUrl { get; set; }
        public string ItemName { get; set; } //mouse, keyboard, headset
        public string ItemCondition { get; set; } // axali, axalivit, meoradi
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Connection { get; set; }
        public string Wireless { get; set; }
        public string CableLength { get; set; }
        public string Price { get; set; }
        public string Colour { get; set; }
        public string RGB { get; set; }

    }
}
