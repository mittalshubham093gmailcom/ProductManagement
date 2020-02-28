using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IServices;
using ProductManagement.Models;
using ProductManagement.Models.viewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.Controllers.ApiControllers
{

    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _ICartService;
        public CartController(ICartService iCartService)
        {
            _ICartService = iCartService;
        }
        [HttpGet("GetItemFromCart")]
        public IEnumerable<Product> GetItemFromCart(int id)
        {

            if (id == 0)
                return new List<Product>();
            else
            {
                var products = _ICartService.GetItemFromCart(id);
                if (products == null || !products.Any())
                    return new List<Product>();
                else
                    return products;
            }
        }

        [HttpPost("AddItemToCart")]
        public Task<int> AddItemToCart([FromBody]CartRQViewModel cart)
        {

            if (cart == null)
                return Task.FromResult(0);
            else
            {
                return _ICartService.AddItemToCart(cart);
               
            }

        }
        [HttpPost("AddMultipleProductsToCart")]
        public Task<int> AddMultipleProductsToCart([FromBody]MultipleProductsCartViewModel cart)
        {

            if (cart == null)
                return Task.FromResult(0);
            else
            {
                return _ICartService.AddMultipleProductsToCart(cart);

            }

        }

        [HttpPost("RemoveItemFromCart")]
        public Task<int> RemoveItemFromCart([FromBody]CartRQViewModel cart)
        {

            if (cart == null)
                return Task.FromResult(0);
            else
            {
                return _ICartService.RemoveItemFromCart(cart);                
            }
        }

        [HttpGet("RemoveAllItemFromCart")]
        public Task<int> RemoveAllItemFromCart(int id)
        {

            if (id == 0)
                return Task.FromResult(0);
            else
            {
                return _ICartService.RemoveAllItemFromCart(id);
            }
        }
    }
}
