using Dollibar.Cllient.Dtos.ManufacturingOrderDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturingOrdersController
    {
        private readonly IManufacturingOrdersService _manufacturingOrdersService;

        public ManufacturingOrdersController(IManufacturingOrdersService manufacturingOrdersService)
        {
            _manufacturingOrdersService = manufacturingOrdersService;
        }

        [HttpGet]
        public async Task<List<ManufacturingOrderDto>> GetManufacturingOrders(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                 long? page = null, string? sqlFilters = null)
        {
            return await _manufacturingOrdersService.GetManufacturingOrders(sortfield, sortorder, limit, page, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<ManufacturingOrderDto> GetManufacturingOrder(int id)
        {
            return await _manufacturingOrdersService.GetManufacturingOrder(id);
        }

        [HttpPost]
        public async Task<string> CreateManufacturingOrder(ManufacturingOrderDto manufacturingOrder)
        {
            return await _manufacturingOrdersService.CreateManufacturingOrder(manufacturingOrder);
        }

        [HttpPut("{id:int}")]
        public async Task<ManufacturingOrderDto> UpdateManufacturingOrder(int id, ManufacturingOrderDto manufacturingOrder)
        {
            return await _manufacturingOrdersService.UpdateManufacturingOrder(id, manufacturingOrder);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteManufacturingOrder(int id)
        {
            return await _manufacturingOrdersService.DeleteManufacturingOrder(id);
        }
    }
}
