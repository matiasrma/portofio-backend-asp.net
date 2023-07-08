using MySqlConnector;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("PortfolioMySqlConnection");
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));

var services = builder.Services;
var serviceFactory = new ServiceFactory(services);
serviceFactory.AddCustomServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
    );

app.MapControllers();

app.Run();
