using Microsoft.EntityFrameworkCore;
using BiggerBasket.Models;

namespace BiggerBasket.Models
{
    public class BiggerBasketContext :DbContext
    {
        public BiggerBasketContext()
        {
        }

        public BiggerBasketContext(DbContextOptions<BiggerBasketContext> options): base(options)
        {
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Cart>  carts { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Admin> Admin { get; set; }

    }

}
  
