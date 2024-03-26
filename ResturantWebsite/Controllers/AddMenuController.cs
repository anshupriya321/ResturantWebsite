using Microsoft.AspNetCore.Mvc;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models;

namespace RestaurantWebsite.Controllers
{ public class AddMenuController : Controller
    {

        private readonly RestroDbContext _RestroDemoDbContext;

   

        public AddMenuController(RestroDbContext RestroDemoDbContext)


        {
            _RestroDemoDbContext = RestroDemoDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Menu menu, List<IFormFile> MenuImage)
        {
            foreach (var item in MenuImage)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);

                        menu.MenuImage = stream.ToArray();

                    }
                }
            }

            _RestroDemoDbContext.Menus.Add(menu);
            _RestroDemoDbContext.SaveChanges();
            return View();
        }


        //SubMenu COntroller 


        [HttpGet]
        public IActionResult SubMenu()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubMenu(SubMenu1 submenu, List<IFormFile> SubMenuImage)
        {
            foreach (var item in SubMenuImage)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);

                        submenu.SubMenuImage = stream.ToArray();

                    }
                }
            }

            _RestroDemoDbContext.SubMenus.Add(submenu);
            _RestroDemoDbContext.SaveChanges();
            return View();
        }
    }
}
