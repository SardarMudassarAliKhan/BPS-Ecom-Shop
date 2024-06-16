using BPS_Ecom_Shop.Data;
using BPS_Ecom_Shop.IRepositories;
using BPS_Ecom_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace BPS_Ecom_Shop.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;

        

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Pie> Pies => appDbContext.Pies.Include(c => c.Category);
        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Include(c => c.Category);

        public void CreatePie(Pie pie)
        {
            appDbContext.Pies.Add(pie);
            appDbContext.SaveChanges();
        }

        public Pie GetPieById(int pieId) => appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);

        public void UpdatePie(Pie pie)
        {
            appDbContext.Pies.Update(pie);
            appDbContext.SaveChanges();
        }
    }
}
