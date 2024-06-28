using Dollibar.Cllient.Dtos.SetupDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(11)]
    public class SetupServiceTest
    {
        private readonly ISetupService _setupService;
        private static int countryId;
        private static int regionId;
        private static int stateId;


        public SetupServiceTest(ISetupService setupService) => _setupService = setupService;

        [Fact, Order(1)]
        public async Task GetAvailability()
        {
            var result = await _setupService.GetAvailability();
            Assert.NotNull(result);
            Assert.IsType<List<AvailabilityDto>>(result);
        }

        [Fact, Order(2)]
        public async Task GetCivilities()
        {
            var result = await _setupService.GetCivilities();
            Assert.NotNull(result);
            Assert.IsType<List<CivilityDto>>(result);
        }

        [Fact, Order(3)]
        public async Task GetContactTypes()
        {
            var result = await _setupService.GetContactTypes();
            Assert.NotNull(result);
            Assert.IsType<List<ContactTypeDto>>(result);
        }

        [Fact, Order(4)]
        public async Task GetCountries()
        {
            var result = await _setupService.GetCountries();
            Assert.NotNull(result);
            Assert.IsType<List<CountryDto>>(result);
            countryId = result.Last().Id;
        }

        [Fact, Order(5)]
        public async Task GetCountry()
        {
            var result = await _setupService.GetCountry(countryId);
            Assert.NotNull(result);
            Assert.IsType<CountryDto>(result);
            Assert.Equal("SX", result.Code);
            Assert.Equal("Sint Maarten", result.Label);

        }

        [Fact, Order(6)]
        public async Task GetCountryByCode()
        {
            var result = await _setupService.GetCountryByCode("AD");
            Assert.NotNull(result);
            Assert.IsType<CountryDto>(result);
            Assert.Equal("AND", result.Code_iso);
            Assert.Equal("Andorra", result.Label);

        }

        [Fact, Order(7)]
        public async Task GetCountryByISO()
        {
            var result = await _setupService.GetCountryByISO("AND");
            Assert.NotNull(result);
            Assert.IsType<CountryDto>(result);
            Assert.Equal("AD", result.Code);
            Assert.Equal("Andorra", result.Label);

        }

        [Fact, Order(8)]
        public async Task GetCurrencies()
        {
            var result = await _setupService.GetCurrencies();
            Assert.NotNull(result);
            Assert.IsType<List<CurrencyDto>>(result);
        }

        [Fact, Order(9)]
        public async Task GetEventTypes()
        {
            var result = await _setupService.GetEventTypes();
            Assert.NotNull(result);
            Assert.IsType<List<EventTypeDto>>(result);
        }

        [Fact, Order(10)]
        public async Task GetExpenseReportTypes()
        {
            var result = await _setupService.GetExpenseReportTypes();
            Assert.NotNull(result);
            Assert.IsType<List<ExpenseReportTypeDto>>(result);
        }

        [Fact, Order(11)]
        public async Task GetIncoterms()
        {
            var result = await _setupService.GetIncoterms();
            Assert.NotNull(result);
            Assert.IsType<List<IncotermDto>>(result);
        }

        [Fact, Order(12)]
        public async Task GetLegalForm()
        {
            var result = await _setupService.GetLegalForm();
            Assert.NotNull(result);
            Assert.IsType<List<LegalFormDto>>(result);
        }

        [Fact, Order(13)]
        public async Task GetOrderingMethods()
        {
            var result = await _setupService.GetOrderingMethods();
            Assert.NotNull(result);
            Assert.IsType<List<OrderingMethodDto>>(result);
        }

        [Fact, Order(14)]
        public async Task GetOrderingOrigins()
        {
            var result = await _setupService.GetOrderingOrigins();
            Assert.NotNull(result);
            Assert.IsType<List<OrderingOriginDto>>(result);
        }

        [Fact, Order(15)]
        public async Task GetPaymentTerms()
        {
            var result = await _setupService.GetPaymentTerms();
            Assert.NotNull(result);
            Assert.IsType<List<PaymentTermsDto>>(result);
        }

        [Fact, Order(16)]
        public async Task GetPaymentTypes()
        {
            var result = await _setupService.GetPaymentTypes();
            Assert.NotNull(result);
            Assert.IsType<List<PaymentTypeDto>>(result);
        }

        [Fact, Order(17)]
        public async Task GetRegions()
        {
            var result = await _setupService.GetRegions();
            Assert.NotNull(result);
            Assert.IsType<List<RegionDto>>(result);
            regionId = result.Last().Id;
        }

        [Fact, Order(18)]
        public async Task GetRegion()
        {
            var result = await _setupService.GetRegion(regionId);
            Assert.NotNull(result);
            Assert.IsType<RegionDto>(result);

        }

        [Fact, Order(19)]
        public async Task GetRegionByCode()
        {
            var result = await _setupService.GetRegionByCode("2");
            Assert.NotNull(result);
            Assert.IsType<RegionDto>(result);
            Assert.Equal("Martinique", result.Name);
            Assert.Equal("97209", result.Cheflieu);

        }

        [Fact, Order(20)]
        public async Task GetShippingMethods()
        {
            var result = await _setupService.GetShippingMethods();
            Assert.NotNull(result);
            Assert.IsType<List<ShippingMethodDto>>(result);
        }

        [Fact, Order(21)]
        public async Task GetSocialNetworks()
        {
            var result = await _setupService.GetSocialNetworks();
            Assert.NotNull(result);
            Assert.IsType<List<SocialNetworkDto>>(result);
        }

        [Fact, Order(22)]
        public async Task GetStaff()
        {
            var result = await _setupService.GetStaff();
            Assert.NotNull(result);
            Assert.IsType<List<StaffDto>>(result);
        }

        [Fact, Order(23)]
        public async Task GetStates()
        {
            var result = await _setupService.GetStates();
            Assert.NotNull(result);
            Assert.IsType<List<StateDto>>(result);
            stateId = result.Last().Id;
        }

        [Fact, Order(24)]
        public async Task GetState()
        {
            var result = await _setupService.GetState(stateId);
            Assert.NotNull(result);
            Assert.IsType<StateDto>(result);
            Assert.Equal("Oum El Bouaghi", result.Name);
            Assert.Equal("04", result.Code);
            Assert.Equal("Oum El Bouaghi", result.Nom);

        }

        [Fact, Order(25)]
        public async Task GetStateByCode()
        {
            var result = await _setupService.GetStateByCode("001");
            Assert.NotNull(result);
            Assert.IsType<StateDto>(result);
            Assert.Equal("Belisario Boeto", result.Name);
            Assert.Equal("Belisario Boeto", result.Nom);

        }

        [Fact, Order(26)]
        public async Task GetTicketCategories()
        {
            var result = await _setupService.GetTicketCategories();
            Assert.NotNull(result);
            Assert.IsType<List<TicketCategoryDto>>(result);
        }

        [Fact, Order(27)]
        public async Task GetTicketSeverities()
        {
            var result = await _setupService.GetTicketSeverities();
            Assert.NotNull(result);
            Assert.IsType<List<TicketSeveritiesDto>>(result);
        }

        [Fact, Order(28)]
        public async Task GetTicketTypes()
        {
            var result = await _setupService.GetTicketTypes();
            Assert.NotNull(result);
            Assert.IsType<List<TicketTypeDto>>(result);
        }

        [Fact, Order(29)]
        public async Task GetUnits()
        {
            var result = await _setupService.GetUnits();
            Assert.NotNull(result);
            Assert.IsType<List<UnitDto>>(result);
        }
    }
}
