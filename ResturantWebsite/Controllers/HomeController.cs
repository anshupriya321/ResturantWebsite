using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models;
using ResturantWebsite.Models;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace RestaurantWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestroDbContext RestroDemoDbContext;


        public HomeController(RestroDbContext RestroDemoDbContext)


        {
            this.RestroDemoDbContext = RestroDemoDbContext;
        }

        List<SubMenu1> li = new List<SubMenu1>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListView()
        {
            var menus = await RestroDemoDbContext.Menus.ToListAsync();
            return View(menus);
        }


     
        public async Task<IActionResult> SubMenuView()
        {
            var menus = await RestroDemoDbContext.SubMenus.ToListAsync();
            return View(menus);
        }


        //[HttpGet]
        //public IActionResult SubMenuView(int id)
        //{
        //    SubMenu1 p = RestroDemoDbContext.SubMenus.Where(x => x.SubMenuId == id).SingleOrDefault();

        //    SubMenu1 sub = new SubMenu1();
        //    sub.SubMenuId = id;
        //    sub.SubMenuName = p.SubMenuName;
        //    sub.SubMenuImage = p.SubMenuImage;
        //    sub.Price = p.Price;

        //    li.Add(sub);
        //    ViewBag.subMenuData = li;

        //    if (TempData["SubMenu1"] == null)
        //    {

        //        TempData["SubMenu"] = li;


        //    }
        //    var res = new JsonResult(sub);
        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TotalBill()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Customer()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            var employee = new Customer()
            {
                CId = customer.CId,
                Name = customer.Name,
                Email = customer.Email,


                DateOfBirth = customer.DateOfBirth
            };

            await RestroDemoDbContext.Customers.AddAsync(employee);
            await RestroDemoDbContext.SaveChangesAsync();
            return RedirectToAction("ViewCustomer");
        }

        [HttpGet]
        public async Task<IActionResult> ViewCustomer()
        {
            var employees = await RestroDemoDbContext.Customers.ToListAsync();
            return View(employees);
        }

        [HttpPost]
        public ActionResult UpdateData(Customer model)
        {
            if (ModelState.IsValid)
            {
                RestroDemoDbContext.Entry(model).State = EntityState.Modified;
                RestroDemoDbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpDelete]

        public async Task<IActionResult> DelCustomer(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            
            var cust = await RestroDemoDbContext.Customers.FindAsync(Id);
            if (cust != null)
            {
                RestroDemoDbContext.Customers.Remove(cust);
                await RestroDemoDbContext.SaveChangesAsync();
                return Ok();
            }
            return RedirectToAction("ViewCustomer", "Home");

        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("userSession") != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || RestroDemoDbContext.Customers == null)
            {
                return NotFound();
            }
            var stdData = await RestroDemoDbContext.Customers.FirstOrDefaultAsync();
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}