using Dollibar.Cllient.Dtos.WarehouseDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IWarehousesService
    {
        Task<List<WarehouseDto>> GetWarehouses(string sortfield = "t.ref", string sortorder = "ASC", long limit = 100,
                                               long? page = null, long? category = null, string? sqlFilters = null);
        Task<WarehouseDto> GetWarehouses(int id);
        public Task<string> CreateWarehouse(WarehouseDto warehouse);
        public Task<WarehouseDto> UpdateWarehouse(int id, WarehouseDto warehouse);
        public Task<string> DeleteWarehouse(int id);
    }
}
