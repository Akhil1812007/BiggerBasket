using BiggerBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BiggerBasket.Controllers
{
    public class AdminController : Controller
    {
        private readonly BiggerBasketContext db;
        private readonly ISession session;

        public AdminController(BiggerBasketContext db)
        {
            this.db = db;
            // session = HttpContextAccessor.HttpContext.Session;
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(Admin a)
        {
            if (a.AdminEmail == "akhil@gmail.com" && a.AdminPassword == "12345")
            {
                return RedirectToAction("AdminView");
            }
            var result = (from i in db.Admin
                          where i.AdminEmail == a.AdminEmail && i.AdminPassword == a.AdminPassword
                          select i).SingleOrDefault();
            
            if (result != null)
            {
                HttpContext.Session.SetString("AdminEmail", result.AdminEmail);
                return RedirectToAction("AdminView");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }
        public IActionResult Category()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Category(Category c)
        {
         

            db.Categories.Add(c);
            db.SaveChanges();

            return RedirectToAction("Category");

        }
        public IActionResult AdminView()
        {
            return View(db.Categories.ToList());
        }
    }
}
