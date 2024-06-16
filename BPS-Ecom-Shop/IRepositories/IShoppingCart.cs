using BPS_Ecom_Shop.Models;

namespace BPS_Ecom_Shop.IRepositories
{
    public interface IShoppingCart
    {
        void AddToCart(Pie pie, int amount);
        int RemoveFromCart(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();

        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
