using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BPS_Ecom_Shop.Models
{
    public class Pie
    {
        public int PieId { get; set; }

        [Remote("CheckIfPieNameAlreadyExists", "PieManagement", ErrorMessage = "That name already exists")]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? AllergyInformation { get; set; }
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public string? ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
