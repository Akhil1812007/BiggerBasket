using BiggerBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Data;
namespace BiggerBasket.Controllers
{
    public class CustomerController : Controller
    {
        private readonly BiggerBasketContext db;
        private readonly ISession session;

        public CustomerController(BiggerBasketContext db)
        {
            this.db = db;
        }
        public IActionResult CustomerRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerRegistration(Customer c)
        {
            try
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("CustomerLogin");
            }
            catch (Exception sqlEx)
            {
                return RedirectToAction("CustomerRegistration");
            }
        }
        public IActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerLogin(Customer c)
        {
            var result = (from i in db.Customers
                          where i.CustomerEmail == c.CustomerEmail && i.CustomerPassword == c.CustomerPassword
                          select i).SingleOrDefault();

            if (result != null)
            {
                HttpContext.Session.SetInt32("CustomerId", result.CustomerId);
                HttpContext.Session.SetString("CustomerEmail", result.CustomerEmail);
                return RedirectToAction("CustomerView","Customer");
            }
            else
            {
                return RedirectToAction("CustomerLogin");
            }
        }
        public IActionResult CustomerView()
        {
            ViewBag.CustomerEmail= HttpContext.Session.GetString("CustomerEmail");
            var result = (from i in db.Products.Include(x => x.Category)
                         select i).ToList();
            return View(db.Products.ToList());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {


            Product p = db.Products.Find(id); 
            return View(p);

        }
        [HttpGet]
        public IActionResult AddtoCart(int id)
        {
            HttpContext.Session.SetInt32("PId",id);
            ViewBag.ProductId = id;
            
            return View();
        }
        [HttpPost]
        public IActionResult AddtoCart(Cart c)
        {
            var CustomerId = HttpContext.Session.GetInt32("CustomerId");
            var ProductId = HttpContext.Session.GetInt32("PId");
           
            c.CustomerId = (int)CustomerId;
            c.ProductId = (int)ProductId;
            db.Add(c);
            db.SaveChanges();
            
            return RedirectToAction("CustomerView");

        }

        public IActionResult CartView()
        {
            var CustomerId = HttpContext.Session.GetInt32("CustomerId");
            var result = (from i in db.carts.Include(x => x.Customer).Include(y => y.Product)where i.CustomerId == CustomerId select i).ToList();
            

            return View(result.ToList());

        }
        public  IActionResult Delete(int? id)
        {
            Cart p = db.carts.Find(id);
            return View(p);
  
        }
        [HttpPost]
        public IActionResult Delete(Cart c)
        {
            db.carts.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Cartview");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("RoleSelection", "Parent");
        }
        


    }





    
}
