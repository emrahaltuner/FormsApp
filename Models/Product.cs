using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product  // Product class
    {
        [Display(Name = "Urun ID")] // Id property


        public int ProductId { get; set; } // Id property
        [Required(ErrorMessage = "Ürün Adı giriniz")]
        [Display(Name = "Urun Adı")]

        public string? Name { get; set; }  // Name property

        [Display(Name = "Resim")]
        public string? Image { get; set; } // Image property
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }  // Description property

        [Required(ErrorMessage = "Ürün Fiyat Bilgisi Giriniz")]
        [Range(0, 10000)]
        [Display(Name = "Fiyat")] // Id property
        public decimal? Price { get; set; }  // Price property

        [Required]
        [Display(Name = "Ürün Kategorisi")]
        public int CategoryId { get; set; } // CategoryId property

    }
}
