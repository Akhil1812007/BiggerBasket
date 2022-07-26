using BiggerBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
