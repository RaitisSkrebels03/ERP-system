using Dollibar.API.Dtos;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface ICategoriesService
    {
        public Task<List<CategoryDto>> GetCategories(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                     long? page = null, string? type = null, string? sqlfilters = null);
        public Task<CategoryDto> GetCategory(int id);
        public Task<string> CreateCategory(CategoryDto category);
        public Task<CategoryDto> UpdateCategory(int id, CategoryDto category);
        public Task<string> DeleteCategory(int id);
    }
}
