using Dollibar.Cllient.Dtos.ProductDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(8)]
    public class ProductsServiceTest
    {
        private readonly IProductsService _productsService;
        private static int productId;
        public ProductsServiceTest(IProductsService productsService) => _productsService = productsService;

        [Fact, Order(1)]
        public async Task CreateProduct()
        {
            ProductDto product = new ProductDto()
            {
                Ref = "pref0087",
                Label = "Custom label",
                Description = "This is description",
                Note_public = "This is public note",
                Note_private = "This is private note",
                Weight = "800",
                Url = "http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/product/"
            };
            var result = await _productsService.CreateProduct(product);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetProducts()
        {
            var result = await _productsService.GetProducts();
            Assert.NotNull(result);
            Assert.IsType<List<ProductDto>>(result);
            productId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetProduct()
        {
            var result = await _productsService.GetProduct(productId);
            Assert.NotNull(result);
            Assert.IsType<ProductDto>(result);
            Assert.Equal("pref0087", result.Ref);
            Assert.Equal("Custom label", result.Label);
            Assert.Equal("This is description", result.Description);
            Assert.Equal("This is public note", result.Note_public);
            Assert.Equal("This is private note", result.Note_private);
            Assert.Equal("800", result.Weight);
            Assert.Equal("http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/product/", result.Url);
        }

        [Fact, Order(4)]
        public async Task UpdateProduct()
        {
            ProductDto product = new ProductDto()
            {
                Ref = "pref0087",
                Label = "Updated label",
                Description = "This is description",
                Note_public = "This is public note",
                Note_private = "This is private note",
                Weight = "800",
                Url = "http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/product/",
                Mandatory_period = "0"
            };
            var result = await _productsService.UpdateProduct(productId, product);
            Assert.NotNull(result);
            Assert.IsType<ProductDto>(result);
            Assert.Equal("pref0087", result.Ref);
            Assert.Equal("Updated label", result.Label);
        }

        [Fact, Order(5)]
        public async Task DeleteProduct()
        {
            var result = await _productsService.DeleteProduct(productId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }

}
