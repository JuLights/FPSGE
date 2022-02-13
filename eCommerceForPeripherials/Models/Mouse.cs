using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models
{
    public class Mouse
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ItemImageUrl { get; set; }
        [DataType(DataType.MultilineText)]
        public string Item { get; set; } //mouse, keyboard, headset
        public string Description { get; set; }
        
    }
}
