using Dollibar.API.Dtos;
using Dollibar.Cllient.Dtos.ProductDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetProducts(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                           long? page = null, long? mode = null, long? category = null, string? sqlfilters = null)
        {
            return await _productsService.GetProducts(sortfield, sortorder, limit, page, mode, category, sqlfilters);
        }

        [HttpGet("{id:int}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            return await _productsService.GetProduct(id); 
        }

        [HttpPost]
        public async Task<string> CreateProduct(ProductDto product)
        {
            return await _productsService.CreateProduct(product);
        }

        [HttpPut("{id:int}")]
        public async Task<ProductDto> UpdateProduct(int id, ProductDto product)
        {
            return await  _productsService.UpdateProduct(id, product);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteProduct(int id)
        {
            return await _productsService.DeleteProduct(id);
        }

        [HttpGet("{id:int}/categories")]
        public async Task<List<CategoryDto>> GetProductCategories(int id, string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, long? page = null)
        {
            return await _productsService.GetProductCategories(id, sortfield, sortorder, limit, page);
        }
    }
}
