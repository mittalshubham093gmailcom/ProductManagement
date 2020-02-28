using ProductManagement.Models;
using ProductManagement.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.IServices
{
    public interface IProductService
    {
        int AddProduct(ProductViewModel product);
        IEnumerable<Product> GetAllProduct();
        int DeleteProduct(int productId);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        Product GetProductById(int productId);
        IEnumerable<Category> GetCategories();
    }
}
