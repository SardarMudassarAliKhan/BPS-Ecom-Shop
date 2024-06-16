using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.Repositories;

namespace BPS_Ecom_Shop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
