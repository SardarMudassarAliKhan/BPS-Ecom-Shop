using BPS_Ecom_Shop.Data;
using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.Models;

namespace BPS_Ecom_Shop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IShoppingCartRepository _shoppingCart;


        public OrderRepository(AppDbContext appDbContext, IShoppingCartRepository shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                order.OrderPlaced = DateTime.Now;

                _appDbContext.Orders.Add(order);
                _appDbContext.SaveChanges();

                var shoppingCartItems = _shoppingCart.ShoppingCartItems;

                foreach (var shoppingCartItem in shoppingCartItems)
                {
                    var orderDetail = new OrderDetail()
                    {
                        Amount = shoppingCartItem.Amount,
                        PieId = shoppingCartItem.Pie.PieId,
                        OrderId = order.OrderId,
                        Price = shoppingCartItem.Pie.Price
                    };

                    _appDbContext.OrderDetails.Add(orderDetail);
                    _appDbContext.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void CreatePieGiftOrder(PieGiftOrder pieGiftOrder)
        {
            _appDbContext.PieGiftOrders.Add(pieGiftOrder);
            _appDbContext.SaveChanges();
        }
    }
}
