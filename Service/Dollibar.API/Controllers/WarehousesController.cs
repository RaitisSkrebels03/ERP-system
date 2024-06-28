using Dollibar.Cllient.Dtos.WarehouseDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WarehousesController
    {
        private readonly IWarehousesService _warehousesService;

        public WarehousesController(IWarehousesService warehousesService)
        {
            _warehousesService = warehousesService;
        }

        [HttpGet]
        public async Task<List<WarehouseDto>> GetWarehouses(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                             long? page = null, long? category = null, string? sqlFilters = null)
        {
            return await _warehousesService.GetWarehouses(sortfield, sortorder, limit, page, category, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<WarehouseDto> GetWarehouse(int id)
        {
            return await _warehousesService.GetWarehouses(id);
        }

        [HttpPost]
        public async Task<string> CreateWarehouse(WarehouseDto warehouse)
        {
            return await _warehousesService.CreateWarehouse(warehouse);
        }

        [HttpPut("{id:int}")]
        public async Task<WarehouseDto> UpdateWarehouse(int id, WarehouseDto warehouse)
        {
            return await _warehousesService.UpdateWarehouse(id, warehouse);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteWarehouse(int id)
        {
            return await _warehousesService.DeleteWarehouse(id);
        }
    }
}
