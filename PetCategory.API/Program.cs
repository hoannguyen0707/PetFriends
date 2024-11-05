using PetCategory.API.Data;
using PetCategory.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("PetCategories");
builder.Services.AddSqlite<PetCategoriesContext>(connString);


var app = builder.Build();

app.MapPetsEndpoints();
app.MigrateDbAsync();

app.Run();
