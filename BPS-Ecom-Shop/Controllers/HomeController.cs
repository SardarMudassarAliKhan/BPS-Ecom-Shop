using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BPS_Ecom_Shop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPieRepository pieRepository)
        {
            PieRepository = pieRepository;
        }

        public IPieRepository PieRepository { get; }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel =  new HomeViewModel(PieRepository.PiesOfTheWeek.Where(x=>x.IsPieOfTheWeek));
            return View(homeViewModel);
        }
    }
}
