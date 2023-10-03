using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrustStores.Core.DTOs;
using TrustStores.Core.Interface;
using TrustStores.Core.Model;
using TrustStores.Core.Services;

namespace TrustStores.API.Controllers
{
    public class ProductController: Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper )
        {
           _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {

            var isProductCreated = await _productService.CreateProduct(product);
           
            if (isProductCreated.Data)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest(isProductCreated);
            }
        }
        [HttpGet("Get-Products-by-Id")]
        public async Task<IActionResult> GetOne(int Id)
        {
            try
            {
                var result = await _productService.GetProductById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server error, Please try again later");
            }
            
          
        }

        [HttpGet("Get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
           
                var result = await _productService.GetAllProducts();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            
        }

        [HttpDelete("Delete-product")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var boo = await _productService.DeleteProduct(productId);
                return Ok(boo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update_Product")]
        public async Task<IActionResult> Update(int Id, ProductDto product)
        {
            if (product != null)
            {
                var isProductCreated = await _productService.UpdateProduct(Id, product);
                if (isProductCreated)
                {
                    return Ok(isProductCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
