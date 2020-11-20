using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleManagement.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : SaleManagementController
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _productAppService.GetProducts();
            return products;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateUpdateProductDto input)
        {
            await _productAppService.CreateProduct(input);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, CreateUpdateProductDto input)
        {
            await _productAppService.UpdateProduct(id, input);

            return Ok();
        }

        [HttpGet("{searchString}")]
        public List<ProductDto> SearchProduct(string searchString)

        {
            var productSearch = _productAppService.SearchProduct(searchString);
            return productSearch;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productAppService.DeleteProduct(id);

            return Ok();
        }
    }
}
