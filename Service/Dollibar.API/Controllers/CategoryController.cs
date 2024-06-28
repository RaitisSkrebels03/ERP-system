using Dollibar.API.Dtos;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> GetCategories(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                           long? page = null, string? type = null, string? sqlfilters = null)
        {
            return await _categoriesService.GetCategories(sortfield, sortorder, limit, page, type, sqlfilters);
        }

        [HttpGet("{id:int}")]
        public async Task<CategoryDto> GetCategory(int id)
        {
            return await _categoriesService.GetCategory(id);
        }

        [HttpPost]
        public async Task<string> CreateCategory(CategoryDto category)
        {
            return await _categoriesService.CreateCategory(category);
        }

        [HttpPut("{id:int}")]
        public async Task<CategoryDto> UpdateCategory(int id, CategoryDto category)
        {
            return await _categoriesService.UpdateCategory(id, category);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteCategory(int id)
        {
            return await _categoriesService.DeleteCategory(id);
        }

    }
}

