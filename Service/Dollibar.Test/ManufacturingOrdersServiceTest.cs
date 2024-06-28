using Dollibar.Cllient.Dtos.ManufacturingOrderDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(17)]
    public class ManufacturingOrdersServiceTest
    {
        private readonly IManufacturingOrdersService _manufacturingOrders;
        private static int manufacturingOrderId;
        public ManufacturingOrdersServiceTest(IManufacturingOrdersService manufacturingOrders) => _manufacturingOrders = manufacturingOrders;

        [Fact, Order(1)]
        public async Task CreateUser()
        {
            ManufacturingOrderDto manufacturingOrder = new ManufacturingOrderDto()
            {
                Fk_project = 2,
                Ref = "MO03-0023",
                Label = "This is label",
                Socid = 1,
                Fk_product = 60,
                Qty = 3
            };
            var result = await _manufacturingOrders.CreateManufacturingOrder(manufacturingOrder);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetUsers()
        {
            var result = await _manufacturingOrders.GetManufacturingOrders();
            Assert.NotNull(result);
            Assert.IsType<List<ManufacturingOrderDto>>(result);
            manufacturingOrderId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetUser()
        {
            var result = await _manufacturingOrders.GetManufacturingOrder(manufacturingOrderId);
            Assert.NotNull(result);
            Assert.IsType<ManufacturingOrderDto>(result);
            Assert.Equal("This is label", result.Label);
            Assert.Equal(60, result.Fk_product);
            Assert.Equal(3, result.Qty);
        }

        [Fact, Order(4)]
        public async Task UpdateUser()
        {
            ManufacturingOrderDto manufacturingOrder = new ManufacturingOrderDto()
            {
                Fk_project = 2,
                Ref = "MO03-0023",
                Label = "This is label",
                Socid = 1,
                Fk_product = 60,
                Qty = 3
            };
            var result = await _manufacturingOrders.UpdateManufacturingOrder(manufacturingOrderId, manufacturingOrder);
            Assert.NotNull(result);
            Assert.IsType<ManufacturingOrderDto>(result);
            Assert.Equal("This is label", result.Label);
            Assert.Equal(60, result.Fk_product);
            Assert.Equal(3, result.Qty);
        }

        [Fact, Order(5)]
        public async Task DeleteUser()
        {
            var result = await _manufacturingOrders.DeleteManufacturingOrder(manufacturingOrderId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}

