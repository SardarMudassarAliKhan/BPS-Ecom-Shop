using BPS_Ecom_Shop.Data;
using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.Models;

namespace BPS_Ecom_Shop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> Categories => appDbContext.Categories;
    }
}
