using BPS_Ecom_Shop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BPS_Ecom_Shop.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PieGiftOrder> PieGiftOrders { get; set; }
    }
}
