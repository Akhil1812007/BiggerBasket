using BiggerBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BiggerBasket.Controllers
{
    public class MerchantController : Controller
    {
        private readonly BiggerBasketContext db;
        private readonly ISession session;

        public MerchantController(BiggerBasketContext db)
        {
            this.db = db;
            // session = HttpContextAccessor.HttpContext.Session;
        }
        public IActionResult MerchantRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MerchantRegistration(Merchant m)
        {
            
            try
            {
                db.Merchants.Add(m);
                db.SaveChanges();
                return RedirectToAction("MerchantLogin");
            }
            catch (Exception sqlEx)
            {
                return RedirectToAction("MerchantRegistration");

            }
            
        }
        public IActionResult MerchantLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MerchantLogin(Merchant m)
        {
            var result = (from i in db.Merchants
                          where i.MerchantEmail == m.MerchantEmail && i.MerchantPassword == m.MerchantPassword
                          select i).SingleOrDefault();

            if (result != null)
            {
                HttpContext.Session.SetInt32("MerchantId",result.MerchantId);
                HttpContext.Session.SetString("MerchantEmail", result.MerchantEmail);
                return RedirectToAction("MerchantView", "Product");
            }
            else
            {
                return RedirectToAction("MerchantLogin");
            }
        }
        
    }
}
