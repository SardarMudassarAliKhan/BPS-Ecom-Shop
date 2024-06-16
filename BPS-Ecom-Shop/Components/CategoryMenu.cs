using BPS_Ecom_Shop.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BPS_Ecom_Shop.Components
{
    public class CategoryMenu : ViewComponent
    {
        public ICategoryRepository CategoryRepository { get; }

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = CategoryRepository.Categories.OrderBy(c=>c.CategoryName);

            return View(categories);
        }
    }
}
