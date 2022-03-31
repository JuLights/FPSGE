using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HltvParser
{
    public class PlayersGear
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Team { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Mouse { get; set; }
        public string MouseHz { get; set; }
        public string DPI { get; set; }
        public string Sens { get; set; }
        public string eDPI { get; set; }
        public string ZoomSens { get; set; }
        public string Accel { get; set; }
        public string WinSens { get; set; }
        public string RawInput { get; set; }
        public string Monitor { get; set; }
        public string MonitorHz { get; set; }
        public string GPU { get; set; }
        public string Resolution { get; set; }
        public string AspectRatio { get; set; }
        public string ScalingMode { get; set; }
        public string MousePad { get; set; }
        public string KeyBoard { get; set; }
        public string Headset { get; set; }
        public string CFG { get; set; }

    }
}
