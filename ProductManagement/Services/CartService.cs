using ProductManagement.Connection;
using ProductManagement.IServices;
using ProductManagement.Models;
using ProductManagement.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Services
{
    public class CartService : ICartService
    {
        private readonly DBOperations _DBOperations;
        public CartService(IConnectSQL connectSQL)
        {
            _DBOperations = new DBOperations(connectSQL);
        }
        public Task<int> AddItemToCart(CartRQViewModel cart)
        {
            SqlParameter[] parameter = { new SqlParameter("@cartId", cart.CartId), new SqlParameter("@productId", cart.ProductId) };
             var dt= _DBOperations.SqlOperationToGetData("sp_isSameProductExistsInCart", parameter);
            if(dt !=null && dt.Rows!=null && dt.Rows.Count>0)
                return Task.FromResult(2);
            bool addOperation = _DBOperations.SqlOperationToAddAndDelete("Cart", "sp_AddProductInCart", parameter);
            if (addOperation)
                return Task.FromResult(1);
            else
                return Task.FromResult(0);
        }
        public Task<int> AddMultipleProductsToCart(MultipleProductsCartViewModel cart)
        {
            foreach (var item in cart.ProductIds)
            {
                SqlParameter[] parameter = { new SqlParameter("@cartId", cart.CartId), new SqlParameter("@productId", item) };
                var dt = _DBOperations.SqlOperationToGetData("sp_isSameProductExistsInCart", parameter);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    continue;
                  _DBOperations.SqlOperationToAddAndDelete("Cart", "sp_AddProductInCart", parameter);
            }
            return Task.FromResult(1);
        }

        public IEnumerable<Product> GetItemFromCart(int cartId)
        {
            List<Product> products = new List<Product>();
            SqlParameter[] parameter = { new SqlParameter("@cartId", cartId) };
            DataTable dt = _DBOperations.SqlOperationToGetData("sp_GetItemFromCart", parameter);
            if (dt == null || dt.Rows == null || dt.Rows.Count <= 0)
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

        public Task<int> RemoveAllItemFromCart(int cartId)
        {
            SqlParameter[] parameter = { new SqlParameter("@cartId", cartId) };

            bool addOperation = _DBOperations.SqlOperationToAddAndDelete("Cart", "sp_RemoveAllProductFromCart", parameter);
            if (addOperation)
                return Task.FromResult(1);
            else
                return Task.FromResult(0);
        }

        public Task<int> RemoveItemFromCart(CartRQViewModel cart)
        {
            SqlParameter[] parameter = { new SqlParameter("@cartId", cart.CartId),new SqlParameter("@productId", cart.ProductId) };

            bool addOperation = _DBOperations.SqlOperationToAddAndDelete("Cart", "sp_RemoveProductFromCart", parameter);
            if (addOperation)
                return Task.FromResult(1);
            else
                return Task.FromResult(0);
        }
    }
}
