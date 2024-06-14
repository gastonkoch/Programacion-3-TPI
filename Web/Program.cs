using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Service;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Web.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(setupAction =>
//{
//    setupAction.AddSecurityDefinition("EcommerceApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
//    {
//        Type = SecuritySchemeType.Http,
//        Scheme = "Bearer",
//        Description = "Acá pegar el token generado al loguearse."
//    });

//    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "EcommerceApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
//                }, new List<string>() }
//    });

//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    setupAction.IncludeXmlComments(xmlPath);

//});




string connectionString = builder.Configuration["ConnectionStrings:DBConnectionString"]!;

// Configure the SQLite connection
var connection = new SqliteConnection(connectionString);
connection.Open();

using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}

builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions => dbContextOptions.UseSqlite(connection));


#region Repositories
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderNotificationRepository, OrderNotificationRepository>();
builder.Services.AddScoped<IRepositoryBase<User>, EfRepository<User>>();
builder.Services.AddScoped<IRepositoryBase<Order>, EfRepository<Order>>();
builder.Services.AddScoped<IRepositoryBase<Product>, EfRepository<Product>>();
builder.Services.AddScoped<IRepositoryBase<OrderNotification>, EfRepository<OrderNotification>>();

#endregion

#region Services
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

builder.Services.Configure<AutenticacionServiceOptions>(
    builder.Configuration.GetSection(AutenticacionServiceOptions.AutenticacionService));

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(options =>
//    options.TokenValidationParameters = new()
//    {
//        ValidateIssuer = true, //Issuer hace referencia al que ofrece el servicio de validacion
//        ValidateAudience = true, //Audience aquel al que le pegue a nuestro enpoint sera nuestra audiencia
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["AutenticacionService:Issuer"],
//        ValidAudience = builder.Configuration["AutenticacionService:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AutenticacionService:SecretForKey"]))
//    });
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
