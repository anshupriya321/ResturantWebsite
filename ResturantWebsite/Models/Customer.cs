using System.ComponentModel.DataAnnotations;

namespace RestaurantWebsite.Models
{
    public class Customer
    {
       
        [Key]
        public int CId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? DateOfBirth { get; set; }

    }
}
