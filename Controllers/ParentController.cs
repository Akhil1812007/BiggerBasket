using BiggerBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BiggerBasket.Controllers
{
    public class ParentController : Controller
    {
        private readonly BiggerBasketContext db;
        private readonly ISession session;

        public ParentController(BiggerBasketContext db)
        {
            this.db = db;
          
        }
        public IActionResult RoleSelection()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();      
        }
       
        public IActionResult SearchResult(string SearchPhrase)
        {


            return View(db.Products.Include(x=>x.Category).Where(x => x.ProductName.Contains(SearchPhrase)).ToList());
        }
    }
}
