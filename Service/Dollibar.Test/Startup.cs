using Dollibar.Cllient.Services;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Dollibar.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IProjectsService, ProjectsService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ITasksService, TasksService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IContactsService, ContactsService>();
            services.AddTransient<ITicketsService, TicketsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<ISetupService, SetupService>();
            services.AddTransient<IProposalsService, ProposalsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IThirdpartiesService, ThirdpartiesService>();
            services.AddTransient<IMembersService, MembersService>();
            services.AddTransient<IAgendaEventsService, AgendaEventsService>(); 
            services.AddTransient<IInvoicesService, InvoicesService>();
            services.AddTransient<IManufacturingOrdersService, ManufacturingOrdersService>();
            services.AddHttpClient();
        }
    }
}
