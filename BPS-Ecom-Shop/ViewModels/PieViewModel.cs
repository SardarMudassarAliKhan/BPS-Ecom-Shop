using BPS_Ecom_Shop.Models;

namespace BPS_Ecom_Shop.ViewModels
{
    public class PieViewModel
    {
        public IEnumerable<Pie> pies { get; set; }
        public string CurrentCategory { get; set; }

        public PieViewModel()
        {
             
        }

        public PieViewModel(IEnumerable<Pie> pies , string CurrentCategory)
        {
            this.pies = pies;
            this.CurrentCategory = CurrentCategory;
        }
    }
}
