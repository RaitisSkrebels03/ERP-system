using Dollibar.Cllient.Dtos.SetupDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetupController
    {
        private readonly ISetupService _setupService;

        public SetupController(ISetupService setupService)
        {
            _setupService = setupService;
        }

        [HttpGet("/contact_types")]
        public async Task<List<ContactTypeDto>> GetContactTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, string? type = null,
                                                   string? module = null, long active = 1, string? lang = null, string? sqlFilters = null)
        {
            return await _setupService.GetContactTypes(sortfield, sortorder, limit, page, type, module, active, lang, sqlFilters);
        }

        [HttpGet("/countries")]
        public async Task<List<CountryDto>> GetCountries(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 300,
                                                        long? page = null, string? filter = null, string? lang = null, string? sqlFilters = null)
        {
            return await _setupService.GetCountries(sortfield, sortorder, limit, page, filter, lang, sqlFilters);
        }

        [HttpGet("/countries/{id:int}")]
        public async Task<CountryDto> GetCountry(int id, string? lang = null)
        {
            return await _setupService.GetCountry(id, lang);
        }

        [HttpGet("/countries/byCode/{code}")]
        public async Task<CountryDto> GetCountryByCode(string code, string? lang = null)
        {
            return await _setupService.GetCountryByCode(code, lang);
        }

        [HttpGet("/countries/byISO/{iso}")]
        public async Task<CountryDto> GetCountryByISO(string iso, string? lang = null)
        {
            return await _setupService.GetCountryByISO(iso, lang);
        }

        [HttpGet("/currencies")]
        public async Task<List<CurrencyDto>> GetCurrencies(string sortfield = "code_iso", string sortorder = "ASC", long limit = 100,
                                                        long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetCurrencies(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/availability")]
        public async Task<List<AvailabilityDto>> GetAvailability(string sortfield = "code", string sortorder = "ASC", long limit = 100, 
                                                                 long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetAvailability(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/civilities")]
        public async Task<List<CivilityDto>> GetCivilities(string sortfield = "code", string sortorder = "ASC", long limit = 100,
                                                            long? page = null, string? module = null, long active = 1, string? lang = null, string? sqlFilters = null)
        {
            return await _setupService.GetCivilities(sortfield, sortorder, limit, page, module, active, lang, sqlFilters);
        }

        [HttpGet("/event_types")]
        public async Task<List<EventTypeDto>> GetEventTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100,
                                                        long? page = null, string? type = null, string? module = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetEventTypes(sortfield, sortorder, limit, page, type, module, active, sqlFilters);
        }

        [HttpGet("/expensereport_types")]
        public async Task<List<ExpenseReportTypeDto>> GetExpenseReportTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100,
                                                        long? page = null, string? module = null, long active = 1, string? sqlFilters = null)
        { 
            return await _setupService.GetExpenseReportTypes(sortfield, sortorder, limit, page, module, active, sqlFilters);
        }

        [HttpGet("/incoterms")]
        public async Task<List<IncotermDto>> GetIncoterms(string sortfield = "code", string sortorder = "ASC", long limit = 100,
                                                        long? page = null, string? module = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetIncoterms(sortfield, sortorder, limit, page, module, active, sqlFilters);
        }

        [HttpGet("/legal_form")]
        public async Task<List<LegalFormDto>> GetLegalForm(string sortfield = "rowid", string sortorder = "ASC", long limit = 100,
                                                        long? page = null, long? country = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetLegalForm(sortfield, sortorder, limit, page, country, active, sqlFilters);
        }

        [HttpGet("/ordering_methods")]
        public async Task<List<OrderingMethodDto>> GetOrderingMethods(string sortfield = "code", string sortorder = "ASC", long limit = 100,
                                                       long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetOrderingMethods(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/ordering_origins")]
        public async Task<List<OrderingOriginDto>> GetOrderingOrigins(string sortfield = "code", string sortorder = "ASC", long limit = 100, 
                                                         long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetOrderingOrigins(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/payment_terms")]
        public async Task<List<PaymentTermsDto>> GetPaymentTerms(string sortfield = "sortorder", string sortorder = "ASC", long limit = 100, 
                                                    long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetPaymentTerms(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/payment_types")]
        public async Task<List<PaymentTypeDto>> GetPaymentTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, 
                                                                long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetPaymentTypes(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/regions")]
        public async Task<List<RegionDto>> GetRegions(string sortfield = "code_region", string sortorder = "ASC", long limit = 100, long? page = null,
                                         long? country = null, string? filter = null, string? sqlFilters = null)
        {
            return await _setupService.GetRegions(sortfield, sortorder, limit, page, country, filter, sqlFilters);
        }

        [HttpGet("/regions/{id:int}")]
        public async Task<RegionDto> GetRegion(int id)
        {
            return await _setupService.GetRegion(id);
        }

        [HttpGet("/regions/byCode/{code}")]
        public async Task<RegionDto> GetRegionByCode(string code)
        {
            return await _setupService.GetRegionByCode(code);
        }

        [HttpGet("/shipping_methods")]
        public async Task<List<ShippingMethodDto>> GetShippingMethods(long limit = 100, long? page = null, long? active = 1, string? lang = null, string? sqlFilters = null)
        {
            return await _setupService.GetShippingMethods(limit, page, active, lang, sqlFilters);
        }

        [HttpGet("/socialnetworks")]
        public async Task<List<SocialNetworkDto>> GetSocialNetworks(string sortfield = "rowid", string sortorder = "ASC", long limit = 100, 
                                                                    long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetSocialNetworks(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/staff")]
        public async Task<List<StaffDto>> GetStaff(string sortfield = "id", string sortorder = "ASC", long limit = 100, 
                                                    long? page = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetStaff(sortfield, sortorder, limit, page, active, sqlFilters);
        }

        [HttpGet("/states")]
        public async Task<List<StateDto>> GetStates(string sortfield = "code_departement", string sortorder = "ASC", long limit = 100, long? page = null, 
                                                    long? country = null, string? filter = null, string? sqlFilters = null)
        {
            return await _setupService.GetStates(sortfield, sortorder, limit, page, country, filter, sqlFilters);
        }

        [HttpGet("/states/{id:int}")]
        public async Task<StateDto> GetState(int id)
        {
            return await _setupService.GetState(id);
        }

        [HttpGet("/states/byCode/{id:int}")]
        public async Task<StateDto> GetStateByCode(string code)
        {
            return await _setupService.GetStateByCode(code);
        }

        [HttpGet("/ticket_categories")]
        public async Task<List<TicketCategoryDto>> GetTicketCategories(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, 
                                                                        long active = 1, string? lang = null, string? sqlFilters = null)
        {
            return await _setupService.GetTicketCategories(sortfield, sortorder, limit, page, active, lang, sqlFilters);
        }

        [HttpGet("/ticket_severities")]
        public async Task<List<TicketSeveritiesDto>> GetTicketSeverities(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null,
                                                                         long active = 1, string? lang = null, string? sqlFilters = null)
        {
            return await _setupService.GetTicketSeverities(sortfield, sortorder, limit, page, active, lang, sqlFilters);
        }

        [HttpGet("/ticket_types")]
        public async Task<List<TicketTypeDto>> GetTicketTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null,
                                                                long active = 1, string? lang = null, string? sqlFilters = null)
        {
            return await _setupService.GetTicketTypes(sortfield, sortorder, limit, page, active, lang, sqlFilters);
        }

        [HttpGet("/towns")]
        public async Task<List<TownDto>> GetTowns(string sortfield = "zip%2Ctown", string sortorder = "ASC", long limit = 100, long? page = null, 
                                                  string? zipcode = null, string? town = null, long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetTowns(sortfield, sortorder, limit, page, zipcode, town, active, sqlFilters);
        }

        [HttpGet("/units")]
        public async Task<List<UnitDto>> GetUnits(string sortfield = "rowid", string sortorder = "ASC", long limit = 100, long? page = null, 
                                                    long active = 1, string? sqlFilters = null)
        {
            return await _setupService.GetUnits(sortfield, sortorder, limit, page, active, sqlFilters);
        }
    }
}
