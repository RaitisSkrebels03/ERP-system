using Dollibar.API.Dtos;
using Dollibar.Cllient.Dtos.ProductDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IProductsService
    {
        Task<List<ProductDto>> GetProducts(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                           long? page = null, long? mode = null, long? category = null, string? sqlfilters = null);
        Task<ProductDto> GetProduct(int id);
        Task<string> CreateProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(int id, ProductDto product);
        Task<string> DeleteProduct(int id);
        Task<List<CategoryDto>> GetProductCategories(int id, string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, long? page = null);

    }
}
