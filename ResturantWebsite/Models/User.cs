﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantWebsite.Models
{
    public class User
    {
        [Key]
        [Required]
        public int? UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
