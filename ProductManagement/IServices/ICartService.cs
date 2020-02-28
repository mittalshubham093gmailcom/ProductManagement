using ProductManagement.Models;
using ProductManagement.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.IServices
{
    public interface ICartService
    {

        IEnumerable<Product> GetItemFromCart(int cartId);
        Task<int> AddItemToCart(CartRQViewModel cart);
        Task<int> AddMultipleProductsToCart(MultipleProductsCartViewModel cart);
        Task<int> RemoveItemFromCart(CartRQViewModel cart);
        Task<int> RemoveAllItemFromCart(int cartId);
    }
}
