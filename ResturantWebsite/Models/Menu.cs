using System.ComponentModel.DataAnnotations;

namespace RestaurantWebsite.Models
{
    public class Menu
    {

        [Key]
        public int? MenuId { get; set; }
        public string? MenuName { get; set; }
        public Byte[]? MenuImage { get; set; }

    }
}



   

