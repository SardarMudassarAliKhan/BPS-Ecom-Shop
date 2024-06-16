using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BPS_Ecom_Shop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            PieViewModel pieViewModel = new PieViewModel(pieRepository.Pies, "All Pies");
            return View(pieViewModel);
        }

        public IActionResult Details(int Id)
        {
            var pie = pieRepository.GetPieById(Id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
