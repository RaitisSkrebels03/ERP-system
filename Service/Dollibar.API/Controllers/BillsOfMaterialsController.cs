using Dollibar.Cllient.Dtos.AgendaEventDto;
using Dollibar.Cllient.Dtos.BillOfMaterialDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BillsOfMaterialsController : ControllerBase
    {
        private readonly IBillsOfMaterialService _billsOfMaterial ;

        public BillsOfMaterialsController(IBillsOfMaterialService billsOfMaterial)
        {
            _billsOfMaterial = billsOfMaterial;
        }
        
        [HttpGet]
        public async Task<List<BillOfMaterialDto>> GetAgendaEvents(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? sqlFilters = null)
        {
            return await _billsOfMaterial.GetBillsOfMaterials(sortfield, sortorder, limit, page, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<BillOfMaterialDto> GetAgendaEvent(int id)
        {
            return await _billsOfMaterial.GetBillOfMaterials(id);
        }

        [HttpPost]
        public async Task<string> CreateAgendaEvent(BillOfMaterialDto billOfMaterial)
        {
            return await _billsOfMaterial.CreateBillOfMaterials(billOfMaterial);
        }

        [HttpPut("{id:int}")]
        public async Task<BillOfMaterialDto> UpdateAgendaEvent(int id, BillOfMaterialDto billOfMaterial)
        {
            return await _billsOfMaterial.UpdateBillOfMaterials(id, billOfMaterial);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteAgendaEvent(int id)
        {
            return await _billsOfMaterial.DeleteBillOfMaterials(id);
        }
    }
}
