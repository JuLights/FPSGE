
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HltvParser
{
	public class Player
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Maps { get; set; }
		public int Rounds { get; set; }
		public string KD_Diff { get; set; }
		public string KD  { get; set; }
		public string Rating { get; set; }
	}
}