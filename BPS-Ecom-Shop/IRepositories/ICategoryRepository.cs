using BPS_Ecom_Shop.Models;

namespace BPS_Ecom_Shop.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
