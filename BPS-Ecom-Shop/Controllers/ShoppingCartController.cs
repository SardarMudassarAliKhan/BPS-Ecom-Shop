using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.Repositories;
using BPS_Ecom_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BPS_Ecom_Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly IShoppingCart shoppingCartRepo;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCartRepo)
        {
            //this.shoppingCart = shoppingCart;
            this.pieRepository = pieRepository;
            this.shoppingCartRepo = shoppingCartRepo;
        }

        public IActionResult Index()
        {
            var items = shoppingCartRepo.GetShoppingCartItems();
            shoppingCartRepo.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCartRepo,
                ShoppingCartTotal = shoppingCartRepo.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int Id)
        {
            var selectedPie = pieRepository.Pies.FirstOrDefault(p => p.PieId == Id);

            if (selectedPie != null)
            {
                shoppingCartRepo.AddToCart(selectedPie, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedPie = pieRepository.Pies.FirstOrDefault(p => p.PieId == Id);

            if (selectedPie != null)
            {
                shoppingCartRepo.RemoveFromCart(selectedPie);
            }

            return RedirectToAction("Index");
        }
    }
}
