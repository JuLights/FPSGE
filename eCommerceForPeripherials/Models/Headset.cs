using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Models
{
    public class Headset
    {
        [Key]
        public int Id { get; set; }
        [Required]
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
        public string FrequencyResponse { get; set; }
        public int Sensitivity { get; set; } //db decibali	107 db
        public string Chatmix { get; set; }
        public string MuteToggle { get; set; }
        public string VolumeControl { get; set; }
        public string ActiveNoise { get; set; }
        public string cancellation { get; set; } //yes or no
        public string Microphone { get; set; } //yes or no
        public string MicFrequencyResponse { get; set; } //mic
        public string Detachable { get; set; } // yes or no
        public string Driver { get; set; } //yes or no
    }
}
