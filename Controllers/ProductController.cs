using BiggerBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BiggerBasket.Controllers
{
    public class ProductController : Controller
    {
        private readonly BiggerBasketContext db;
        private readonly ISession session;

        public ProductController(BiggerBasketContext db)
        {
            this.db = db;
            
        }
        public IActionResult AddProduct()
        {
            var ans = HttpContext.Session.GetInt32("MerchantId");
            ViewBag.MerchantId = ans;
            var CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            var MerchantId = HttpContext.Session.GetInt32("MerchantId");
            p.MerchantId =(int) MerchantId;

            db.Products.Add(p);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult MerchantView()
        {
            var ans1= HttpContext.Session.GetInt32("MerchantId");
            var MerchantEmail = (from i in db.Merchants where i.MerchantId == ans1 select i).SingleOrDefault();
            ViewBag.ans = HttpContext.Session.GetString("MerchantEmail");


            var result = (from i in db.Products.Include(x => x.Category)
                          where i.MerchantId == ans1
                          select i).ToList();
            return View(result.ToList());
        }
        public async Task<IActionResult> Edit(int id)
        {
            var CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryId", "CategoryName");
            var product = await db.Products.FindAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductCategory,UnitPrice,ProductImage,CategoryId,MerchantId")] Product product)
        {
            db.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("MerchantView");

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound("MerchantView");
            }

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction();
        }



    }
}
