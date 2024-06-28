using Dollibar.API.Dtos;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(3)]
    public class CategoriesServiceTest
    {
        private readonly ICategoriesService _categoriesService;
        private static int categoryId;

        public CategoriesServiceTest(ICategoriesService categoriesService) => _categoriesService = categoriesService;

        [Fact, Order(1)]
        public async Task CreateCategory()
        {
            CategoryDto categories = new CategoryDto()
            {
                Ref = "RF005",
                Label = "Our label",
                Description = "This is description",
                Fk_parent = 0,
                Type = "0"
            };
            var result = await _categoriesService.CreateCategory(categories);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetCategories()
        {
            var result = await _categoriesService.GetCategories();
            Assert.NotNull(result);
            Assert.IsType<List<CategoryDto>>(result);
            categoryId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetCategory()
        {
            var result = await _categoriesService.GetCategory(categoryId);
            Assert.NotNull(result);
            Assert.IsType<CategoryDto>(result);
            //Assert.Equal("", result.Ref);
            Assert.Equal("Our label", result.Label);
            Assert.Equal(0, result.Fk_parent);
            Assert.Equal("0", result.Type);
            Assert.Equal("This is description", result.Description);
        }

        [Fact, Order(4)]
        public async Task UpdateCategory()
        {
            CategoryDto category = new CategoryDto()
            { 
                Ref = "RF005",
                Label = "Updated label",
                Description = "This is description",
                Fk_parent = 0
            };
            var result = await _categoriesService.UpdateCategory(categoryId, category);
            Assert.NotNull(result);
            Assert.IsType<CategoryDto>(result);
            Assert.Equal("RF005", result.Ref);
            Assert.Equal("Updated label", result.Label);
        }

        [Fact, Order(5)]
        public async Task DeleteCategory()
        {
            var result = await _categoriesService.DeleteCategory(categoryId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
