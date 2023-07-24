using LogicaDominio.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// AGREGAMOS EL SECRET
var appSettingsSecions = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSecions);

var appSettings = appSettingsSecions.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(d =>
    {
        d.RequireHttpsMetadata = false;
        d.SaveToken = true;
        d.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// SERVICES DE TODOS LAS ENTIDADES
string connectionString = builder.Configuration.GetConnectionString("PortfolioMySqlConnection");
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));

var services = builder.Services;
var serviceFactory = new ServiceFactory(services);
serviceFactory.AddCustomServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
    );

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
