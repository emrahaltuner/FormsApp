using Microsoft.AspNetCore.Authentication;

namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Phone" });
            _categories.Add(new Category { CategoryId = 2, Name = "Camputer" });

            _products.Add(new Product { ProductId = 1, Name = "Samsung S5", Image = "1.jpg", Price = 2000, IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "İphone 16 pro max", Image = "2.jpg", Price = 3000, IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "İphone 16 pro max", Image = "3.jpg", Price = 4000, IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "İphone 14 pro max", Image = "4.jpg", Price = 6000, IsActive = true, CategoryId = 1 });

            _products.Add(new Product { ProductId = 2, Name = "Macbook Air", Image = "5.jpg", Price = 9000, IsActive = true, CategoryId = 2 });
            _products.Add(new Product { ProductId = 2, Name = "Macbook Pro m2", Image = "6.jpg", Price = 12000, IsActive = true, CategoryId = 2 });
        }
        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);

        }

        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if (entity != null)
            {
                entity.Name = updatedProduct.Name;
                entity.Price = updatedProduct.Price;
                entity.Image = updatedProduct.Image;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }

        }

    }
}