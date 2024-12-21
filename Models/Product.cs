namespace FormsApp.Models
{
    public class Product  // Product class
    {
        public int ProductId { get; set; }  // Id property
        public string Name { get; set; } = string.Empty;  // Name property
        public string Image { get; set; } = string.Empty; // Image property
        public bool IsActive { get; set; }  // Description property
        public decimal Price { get; set; }  // Price property
        public int CategoryId { get; set; } // CategoryId property
    }
}
