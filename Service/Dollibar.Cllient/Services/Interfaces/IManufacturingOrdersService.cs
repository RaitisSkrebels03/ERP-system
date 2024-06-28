using Dollibar.Cllient.Dtos.ManufacturingOrderDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IManufacturingOrdersService
    {
        Task<List<ManufacturingOrderDto>> GetManufacturingOrders(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                                 long? page = null, string? sqlfilters = null);
        Task<ManufacturingOrderDto> GetManufacturingOrder(int id);
        Task<string> CreateManufacturingOrder(ManufacturingOrderDto manufacturingOrder);
        Task<ManufacturingOrderDto> UpdateManufacturingOrder(int id,  ManufacturingOrderDto manufacturingOrder);
        Task<string> DeleteManufacturingOrder(int id);

    }
}
