using ProductManagement.IServices;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProductManagement.Connection;
using ProductManagement.Models.viewModels;

namespace ProductManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly DBOperations _DBOperations;
        public ProductService(IConnectSQL connectSQL)
        {
            _DBOperations = new DBOperations(connectSQL);
        }

        public int AddProduct(ProductViewModel product)
        {
            int val = 10;
            SqlParameter[] parameter = { 
            new SqlParameter("@name",product.Name),
            new SqlParameter("@price",product.Price),
            new SqlParameter("@rewards",val),
            new SqlParameter("@image",product.Image),
            new SqlParameter("@categoryId",product.CategoryId)};

            bool addOperation = _DBOperations.SqlOperationToAddAndDelete("Product", "sp_AddProduct", parameter);
            if (addOperation)
                return 1;
            else
                return 0;

        }

        public int DeleteProduct(int productId)
        {
            SqlParameter[] parameter = { new SqlParameter("@productId", productId) };

            bool addOperation = _DBOperations.SqlOperationToAddAndDelete("Product", "sp_DeleteProduct", parameter);
            if (addOperation)
                return 1;
            else
                return 0;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            List<Product> products = new List<Product>();
            DataTable dt = _DBOperations.SqlOperationToGetData("sp_GetAllProducts");
            if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
                return products;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Name = Convert.ToString(dt.Rows[i]["Name"]),
                    Price = Convert.ToDecimal(dt.Rows[i]["Price"]),
                    CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"])
                });


            }
            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = new Product();

            SqlParameter[] sqlParameters = { new SqlParameter("@productId", productId) };
            DataTable dt = _DBOperations.SqlOperationToGetData("sp_GetProductById", sqlParameters);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                product = new Product
                {
                    Id = Convert.ToInt32(dt.Rows[i]["StudentId"]),
                    Name = Convert.ToString(dt.Rows[i]["StudentName"]),
                    Price = Convert.ToDecimal(dt.Rows[i]["Address"]),
                    CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"])
                };
            }
            return product;
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            DataTable dt = _DBOperations.SqlOperationToGetData("sp_GetCategories");
            if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
                return categories;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                categories.Add(new Category
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Name = Convert.ToString(dt.Rows[i]["Name"]),
                });


            }
            return categories;
        }
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            List<Product> products = new List<Product>();
            SqlParameter[] sqlParameters = { new SqlParameter("@categoryId", categoryId) };
            DataTable dt = _DBOperations.SqlOperationToGetData("sp_GetProductsBasedOnCategory", sqlParameters);
            if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
                return products;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Name = Convert.ToString(dt.Rows[i]["Name"]),
                    Price = Convert.ToDecimal(dt.Rows[i]["Price"]),
                    CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"])
                });

            }
            return products;
        }
    }
}
