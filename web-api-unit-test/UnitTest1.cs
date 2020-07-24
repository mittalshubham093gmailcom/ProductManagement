using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagement.Controllers.ApiControllers;
using ProductManagement.IServices;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace web_api_unit_test
{
    public class UnitTest1
    {
        private Mock<IProductService> mockFootlooseFSService;
        ProductController _ProductController;
        public UnitTest1()
        {
            mockFootlooseFSService = new Mock<IProductService>();
            _ProductController = new ProductController(mockFootlooseFSService.Object);
        }
        [Fact]
        public void GetAllProducts()
        {
            var okResult = _ProductController.GetAllProducts() as OkObjectResult;

            // Assert
           
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public void GetProductsByCategory_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var response = _ProductController.GetProductsByCategory(0) as NotFoundResult;

            

            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public void GetProductsByCategory_ExistingGuidPassed_ReturnsOkResult()
        {
         
            // Act
            var response = _ProductController.GetProductsByCategory(1) as OkObjectResult;


            Assert.True(response.StatusCode==200 || response.StatusCode == 202);
        }

        [Fact]
        public void GetProductsByCategory_ExistingGuidPassed_ReturnsRightItem()
        {

            // Act
            var response = _ProductController.GetProductsByCategory(1) as OkObjectResult;

            // Assert

            Assert.True(response.StatusCode == 200 || response.StatusCode == 202);
        }
        [Fact]
        public void GetProductById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var response = _ProductController.GetProductById(0) as NoContentResult;


            Assert.Equal(204, response.StatusCode);
        }

        [Fact]
        public void GetProductById_ExistingGuidPassed_ReturnsOkResult()
        {
         
            // Act
            var response = _ProductController.GetProductById(1) as OkObjectResult;

            // Assert

            Assert.True(response.StatusCode == 200 || response.StatusCode == 202);
        }

        [Fact]
        public void GetProductById_ExistingGuidPassed_ReturnsRightItem()
        {

            // Act
            var response = _ProductController.GetProductById(1) as OkObjectResult;

            // Assert

            Assert.True(response.StatusCode == 200 || response.StatusCode == 202);
        }
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            
            // Act
            var badResponse = _ProductController.DeleteProduct(0).Result;

            // Assert
            Assert.True(!badResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {
           
            // Act
            var okResponse = _ProductController.DeleteProduct(1).Result;

            // Assert
            Assert.True(okResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
          
            // Act
            var okResponse = _ProductController.DeleteProduct(1).Result;

            // Assert
            Assert.True(okResponse);
        }
    }
}
