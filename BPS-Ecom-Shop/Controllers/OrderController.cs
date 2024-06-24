using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.Models;
using BPS_Ecom_Shop.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BPS_Ecom_Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartRepository _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Authorize(Policy = "MinimumOrderAge")]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);

        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = HttpContext.User.Identity.Name +
                                      ", thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
