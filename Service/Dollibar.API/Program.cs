using Dollibar.Cllient.Services;
using Dollibar.Cllient.Services.Interfaces;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddOpenApiDocument(document =>
{
    document.DocumentName = "Dollibar API v1";
    document.Title = "Dollibar API";
    document.Version = "v1";
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IWarehousesService, WarehousesService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IMembersService, MembersService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IThirdpartiesService, ThirdpartiesService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<ISetupService, SetupService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ITicketsService, TicketsService>();
builder.Services.AddScoped<IInvoicesService, InvoicesService>();
builder.Services.AddScoped<IAgendaEventsService, AgendaEventsService>();
builder.Services.AddScoped<IProposalsService, ProposalsService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IManufacturingOrdersService, ManufacturingOrdersService>();
builder.Services.AddScoped<IMembersTypesService, MembersTypesService>();
builder.Services.AddScoped<IBillsOfMaterialService, BillsOfMaterialsService>();


builder.Services.AddSwaggerGen(options =>
{
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseOpenApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
