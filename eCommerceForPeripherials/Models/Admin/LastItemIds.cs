using System.ComponentModel.DataAnnotations;

namespace eCommerceForPeripherials.Models.Admin
{
    public class LastItemIds
    {
        [Key]
        public int Id { get; set; }
        public int LastItemId { get; set; }
    }
}
