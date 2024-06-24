using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BPS_Ecom_Shop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        public IShoppingCartRepository ShoppingCart { get; }

        public ShoppingCartSummary(IShoppingCartRepository shoppingCart)
        {
            ShoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = ShoppingCart.GetShoppingCartItems();
            ShoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = ShoppingCart,
                ShoppingCartTotal = ShoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

    }
}