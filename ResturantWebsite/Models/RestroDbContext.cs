using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Models;
using System.Collections.Generic;

namespace RestaurantWebsite.Data
{
    public class RestroDbContext : DbContext
    {

        public RestroDbContext(DbContextOptions<RestroDbContext> options) : base(options) { }



        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<SubMenu1> SubMenus { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }




    }
}

