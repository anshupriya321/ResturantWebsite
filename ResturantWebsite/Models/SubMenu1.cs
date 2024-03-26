using System.ComponentModel.DataAnnotations;

namespace RestaurantWebsite.Models
{
    public class SubMenu1
    {
        [Key]
        public int SubMenuId { get; set; }

        public string SubMenuName { get; set; }

        public Byte[] SubMenuImage { get; set; }

        public string Price { get; set; }
    }
}
