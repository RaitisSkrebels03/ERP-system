using Dollibar.Cllient.Dtos.OrderDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<List<OrderDto>> GetOrders(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, 
                                                    long? page = null, string? thirdparty_ids = null, long? category = null, string? sqlFilters = null)
        {
            return await _ordersService.GetOrders(sortfield, sortorder, limit, page, thirdparty_ids, category, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<OrderDto> GetOrder(int id)
        {
            return await _ordersService.GetOrder(id);
        }

        [HttpPost]
        public async Task<string> CreateOrder(OrderDto order)
        {
            return await _ordersService.CreateOrder(order);
        }

        [HttpPut("{id:int}")]
        public async Task<OrderDto> UpdateOrder(int id, OrderDto project)
        {
            return await _ordersService.UpdateOrder(id, project);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteOrder(int id)
        {
            return await _ordersService.DeleteOrder(id);
        }
    }
}
