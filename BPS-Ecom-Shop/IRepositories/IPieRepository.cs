using BPS_Ecom_Shop.Models;

namespace BPS_Ecom_Shop.IRepositories
{
    public interface IPieRepository
    {
        IEnumerable<Pie> Pies {get;}

        IEnumerable<Pie> PiesOfTheWeek { get; }

        Pie GetPieById(int pieId);

        void CreatePie(Pie pie);

        void UpdatePie(Pie pie);
    }
}
