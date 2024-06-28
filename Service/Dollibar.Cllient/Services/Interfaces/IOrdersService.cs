using Dollibar.Cllient.Dtos.OrderDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrderDto>> GetOrders(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                       long? page = null, string? thirdparty_ids = null, long? category = null, string? sqlFilters = null);
        Task<OrderDto> GetOrder(int id);
        Task<string> CreateOrder(OrderDto order);
        Task<OrderDto> UpdateOrder(int id, OrderDto order);
        Task<string> DeleteOrder(int id);
    }
}
