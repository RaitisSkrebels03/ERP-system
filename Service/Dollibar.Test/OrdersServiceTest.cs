using Dollibar.Cllient.Dtos.OrderDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(7)]
    public class OrdersServiceTest
    {
        private readonly IOrdersService _ordersService;
        private static int orderId;
        public OrdersServiceTest(IOrdersService ordersService) => _ordersService = ordersService;

        [Fact, Order(1)]
        public async Task CreateOrder()
        {
            OrderDto order = new OrderDto()
            {
                Id = 53 , 
                Fk_project = 2,
                Ref = "(PROV53)",
                Socid = 1,
                Date = 1710288000
            };
            var result = await _ordersService.CreateOrder(order);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetOrders()
        {
            var result = await _ordersService.GetOrders();
            Assert.NotNull(result);
            Assert.IsType<List<OrderDto>>(result);
            orderId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetOrder()
        {
            var result = await _ordersService.GetOrder(orderId);
            Assert.NotNull(result);
            Assert.IsType<OrderDto>(result);
            //Assert.Equal(58, result.Id);
            Assert.Equal("(PROV53)", result.Ref);
            Assert.Equal(1, result.Socid);
            Assert.Equal(2, result.Fk_project);
        }

        [Fact, Order(4)]
        public async Task UpdateOrder()
        {
            OrderDto order = new OrderDto()
            {
                Id = 53,
                Fk_project = 2,
                Ref = "(PROV53)",
                Socid = 1,
                Date = 1710288000

            };
            var result = await _ordersService.UpdateOrder(orderId, order);
            Assert.NotNull(result);
            Assert.IsType<OrderDto>(result);
            Assert.Equal("(PROV53)", result.Ref);
            Assert.Equal(1, result.Socid);
            Assert.Equal(2, result.Fk_project);
        }

        [Fact, Order(5)]
        public async Task DeleteOrder()
        {
            var result = await _ordersService.DeleteOrder(orderId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
