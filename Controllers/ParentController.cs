using BiggerBasket.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiggerBasket.Controllers
{
    public class ParentController : Controller
    {
        private readonly BiggerBasketContext db;
        public IActionResult RoleSelection()
        {
            return View();
        }
    }
}
