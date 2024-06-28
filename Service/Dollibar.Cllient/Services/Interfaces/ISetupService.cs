using Dollibar.Cllient.Dtos.SetupDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface ISetupService
    {
        Task<List<ContactTypeDto>> GetContactTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, string? type = null, string? module = null, long active = 1, string? lang = null, string? sqlFilters = null);
        Task<List<CountryDto>> GetCountries(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 300, long? page = null, string? filter = null, string? lang = null, string? sqlFilters = null);

        Task<CountryDto> GetCountry(int id, string? lang = null);

        Task<CountryDto> GetCountryByCode(string code, string? lang = null);

        Task<CountryDto> GetCountryByISO(string iso, string? lang = null);

        Task<List<CurrencyDto>> GetCurrencies(string sortfield = "code_iso", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<AvailabilityDto>> GetAvailability(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<CivilityDto>> GetCivilities(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, string? module = null, long active = 1, string? lang = null, string? sqlFilters = null);

        Task<List<EventTypeDto>> GetEventTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, string? type = null, string? module = null, long active = 1, string? sqlFilters = null);

        Task<List<ExpenseReportTypeDto>> GetExpenseReportTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, string? module = null, long active = 1, string? sqlFilters = null);

        Task<List<IncotermDto>> GetIncoterms(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, string? module = null, long active = 1, string? sqlFilters = null);

        Task<List<LegalFormDto>> GetLegalForm(string sortfield = "rowid", string sortorder = "ASC", long limit = 100, long? page = null, long? country = null, long active = 1, string? sqlFilters = null);

        Task<List<OrderingMethodDto>> GetOrderingMethods(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<OrderingOriginDto>> GetOrderingOrigins(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<PaymentTermsDto>> GetPaymentTerms(string sortfield = "sortorder", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<PaymentTypeDto>> GetPaymentTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<RegionDto>> GetRegions(string sortfield = "code_region", string sortorder = "ASC", long limit = 100, long? page = null, long? country = null, string? filter = null, string? sqlFilters = null);

        Task<RegionDto> GetRegion(int id);

        Task<RegionDto> GetRegionByCode(string code);

        Task<List<ShippingMethodDto>> GetShippingMethods(long limit = 100, long? page = null, long? active = 1, string? lang = null, string? sqlFilters = null);

        Task<List<SocialNetworkDto>> GetSocialNetworks(string sortfield = "rowid", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<StaffDto>> GetStaff(string sortfield = "id", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

        Task<List<StateDto>> GetStates(string sortfield = "code_departement", string sortorder = "ASC", long limit = 100, long? page = null, long? country = null, string? filter = null, string? sqlFilters = null);

        Task<StateDto> GetState(int id);

        Task<StateDto> GetStateByCode(string code);

        Task<List<TicketCategoryDto>> GetTicketCategories(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? lang = null, string? sqlFilters = null);

        Task<List<TicketSeveritiesDto>> GetTicketSeverities(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? lang = null, string? sqlFilters = null);

        Task<List<TicketTypeDto>> GetTicketTypes(string sortfield = "code", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? lang = null, string? sqlFilters = null);

        Task<List<TownDto>> GetTowns(string sortfield = "zip%2Ctown", string sortorder = "ASC", long limit = 100, long? page = null, string? zipcode = null, string? town = null, long active = 1, string? sqlFilters = null);

        Task<List<UnitDto>> GetUnits(string sortfield = "rowid", string sortorder = "ASC", long limit = 100, long? page = null, long active = 1, string? sqlFilters = null);

    }
}
