using System.ComponentModel.DataAnnotations;

namespace RestaurantWebsite.Models
{
    public class Item
    {

        [Key]
        public int? ItemId { get; set; }

        public string? ItemName { get; set; }

        public string? ItemPrice { get; set; }
    }
}