using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Web.API.Models.Products;
using MyShop.Web.API.Services.Foundation.Products;
using System.Reflection.Metadata.Ecma335;

namespace MyShop.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = this.productService.RetrieveAllProductsAsync().ToList();
            return Ok(products);
        }

        [HttpGet("id", Name = "GetSingleProduct")]
        public async ValueTask<IActionResult> GetProductAsync(Guid id)
        {
            var product = await this.productService.RetrieveProductByIdAsync(id);

            if(product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostProduct([FromBody] Product product)
        {
            var newProduct = await this.productService.AddProductAsync(product);

            return Created("GetSingleProduct", newProduct);
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutProduct([FromBody] Product product)
        {
            var currentProduct = await this.productService.RetrieveProductByIdAsync(product.Id);

            if(currentProduct is null)
            {
                return NotFound();
            }

            var updatedProduct = await this.productService.ModifyProductAsync(product);

            return Ok(updatedProduct);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProduct(Guid id)
        {
            var currentproduct = await this.productService.RetrieveProductByIdAsync(id);

            if(currentproduct is null)
            {
                return NotFound();
            }

            var deletedProduct = await this.productService.RemoveProductAsync(currentproduct);

            return NoContent();
        }
    }
}
