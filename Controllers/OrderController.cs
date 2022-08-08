using BiggerBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiggerBasket.Controllers
{
    public class OrderController : Controller
    {
        private readonly BiggerBasketContext db;
        private readonly ISession session;

        public OrderController(BiggerBasketContext db)
        {
            this.db = db;
            // session = HttpContextAccessor.HttpContext.Session;
        }
       
        [HttpPost]
        public IActionResult ProceedToBuy()
        {
            var CustomerId = HttpContext.Session.GetInt32("CustomerId");
            List<Cart> cart= (from i in db.carts.Include(x=>x.Product) where i.CustomerId == CustomerId select i).ToList();
            
            OrderMaster orderMaster = new OrderMaster();
            List<OrderDetail> orderItems=new List<OrderDetail>();
            orderMaster.OrderDate = DateTime.Today;
            orderMaster.CustomerId =(int) CustomerId;
            foreach (var item in cart)
            {

                orderMaster.total += (item.ProductQuantity * item.Product.UnitPrice);
            }
            db.Add(orderMaster);
           
            db.SaveChanges();
            HttpContext.Session.SetInt32("total", orderMaster.total);
            foreach (var item in cart)
            {
                OrderDetail detail = new OrderDetail();
                detail.ProductId = item.ProductId;
                detail.ProductQuantity = item.ProductQuantity;
                detail.ProductRate = item.Product.UnitPrice;
                detail.OrderMasterId = orderMaster.OrderMasterId;
                orderItems.Add(detail);
            }
            db.AddRange(orderItems);
            db.SaveChanges();
            db.carts.RemoveRange(cart);
            db.SaveChanges();
          
            return RedirectToAction("GetPayment", new {id= orderMaster.OrderMasterId });
            

        }
        [HttpGet]
        //public async Task<IActionResult> Edit(int id, [Bind("AccountNumber,CustomerName,CustomerAddress,CurrentBalance")] Newaccount newaccount)
        public IActionResult GetPayment(int id)
        {
            var OrderMaster = db.OrderMasters.Find(id);
            return View(OrderMaster);
        
        }
        [HttpPost]
        public IActionResult GetPayment(OrderMaster m)
        {
            

            if (m.AmountPaid == m.total )
            {

                db.OrderMasters.Update(m);
                db.SaveChanges();
                return RedirectToAction("Thankyou");
            }
            else
            {
                ViewBag.ErrorMessage = "amount not valid";
                return View(m);
            }
        
        }
        public IActionResult Thankyou()
        {
            return View();
        }



    }
}
