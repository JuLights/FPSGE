using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models
{
    public class Keyboard
    {
        [Key]
        public int Id { get; set; }
        public string ItemImageUrl { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Connection { get; set; }
        public string Wireless { get; set; }
        public string CableLength { get; set; }
        public string Weight { get; set; }
        public string Width { get; set; }
        public string Depth { get; set; }
        public string Height { get; set; }
        public string Colour { get; set; }
        public string MechanicalSwitches { get; set; } //yes or no
        public string SwitchType { get; set; } //color of switch
        public string FormFactor { get; set; } //Compact arvici
        public string BackLight { get; set; } //yes , RGB
        public string MultiMediaKeys { get; set; } //yes or no
    }
}
