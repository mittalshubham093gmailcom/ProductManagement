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
    public class ProductController : Controller
    {
        private readonly IProductService _IProductService;
        public ProductController(IProductService iProductService)
        {
            _IProductService = iProductService;
        }

        // GET: api/<controller>
        [HttpPost("AddProducts")]
        public Task<bool> AddProducts([FromBody]ProductViewModel product)
        {

            if (product == null)
                return Task.FromResult(false);
            else
            {
                if (_IProductService.AddProduct(product) == 1)
                    return Task.FromResult(true);
                else
                    return Task.FromResult(false);
            }

        }

        // GET api/<controller>/5
        [HttpGet]
        public JsonResult GetAllProducts()
        {
            var products = _IProductService.GetAllProduct();
            var categories = _IProductService.GetCategories();
            if ((products == null || !products.Any())&& (categories == null || !categories.Any()))
                return Json(new List<Product>());
            else
            {
                return Json(new {products= products,categories= categories});
            }
               
        }

        [HttpGet("DeleteProduct")]
        public Task<bool> DeleteProduct(int id)
        {

            if (id == 0)
                return Task.FromResult(false);
            else
            {
                if (_IProductService.DeleteProduct(id) == 1)
                    return Task.FromResult(true);
                else
                    return Task.FromResult(true);
            }



        }

        [HttpGet("GetProductsByCategory")]
        public JsonResult GetProductsByCategory(int id)
        {
            if (id ==0)
                return Json(new List<Product>());
            else
            {
                var products = _IProductService.GetProductsByCategory(id);
                if (products == null || !products.Any())
                    return Json(new List<Product>());
                else
                    return Json( products);
            }

        }

        [HttpGet("GetProductById")]
        public Product GetProductById(int id)
        {

            if (id == 0)
                return new Product();
            else
            {
                var product = _IProductService.GetProductById(id);
                if (product == null )
                    return new Product();
                else
                    return product;
            }

        }
    }
}
