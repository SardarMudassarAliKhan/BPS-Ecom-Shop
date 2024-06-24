using BPS_Ecom_Shop.Models;

namespace BPS_Ecom_Shop.IRepositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void CreatePieGiftOrder(PieGiftOrder pieGiftOrder);
    }
}
