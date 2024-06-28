using Dollibar.Cllient.Dtos.BillOfMaterialDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IBillsOfMaterialService
    {
        Task<List<BillOfMaterialDto>> GetBillsOfMaterials(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? sqlFilters = null);

        Task<BillOfMaterialDto> GetBillOfMaterials(int id);

        Task<string> CreateBillOfMaterials(BillOfMaterialDto billOfMaterial);

        Task<BillOfMaterialDto> UpdateBillOfMaterials(int id, BillOfMaterialDto billOfMaterial);

        Task<string> DeleteBillOfMaterials(int id);
    }
}
