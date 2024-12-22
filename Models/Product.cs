using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product  // Product class
    {
        [Display(Name = "Urun ID")] // Id property

        public int ProductId { get; set; } // Id property
        [Display(Name = "Urun Adı")]
        public string Name { get; set; } = string.Empty;  // Name property
        [Display(Name = "Resim")]
        public string Image { get; set; } = string.Empty;// Image property

        public bool IsActive { get; set; }  // Description property
        [Display(Name = "Fiyat")] // Id property

        public decimal Price { get; set; }  // Price property
        public int CategoryId { get; set; } // CategoryId property

    }
}
