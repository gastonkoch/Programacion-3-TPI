using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Enum;
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

// Este cambio genera el boton verde en la parte superior del swagger, para que poder colocar el token
// Crea el boton "Authorize"
builder.Services.AddSwaggerGen(setupAction =>
{
    // Definimos la seguridad que vamos a utilizar en la API
    // Agrega una definición de seguridad para la autenticación Bearer en Swagger
    setupAction.AddSecurityDefinition("EcommerceApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,  // Especifica que el tipo de esquema de seguridad es HTTP
        Scheme = "Bearer", // Especifica que el esquema es "Bearer" (usado para JWT)
        Description = "Acá pegar el token generado al loguearse."  // Descripción que se muestra en la UI de Swagger
    });

    // Definimos el requerimiento de la seguridad que acabamos de crear
    // Agrega un requerimiento de seguridad global para usar el esquema definido anteriormente
    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,  // Especifica que el tipo de referencia es un esquema de seguridad
                    Id = "EcommerceApiBearerAuth" } // ID del esquema de seguridad que debe coincidir con el definido arriba //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() } // Lista de alcances (scopes) requerida para este esquema (vacío en este caso)
    });

    // Incluye los comentarios XML generados por la documentación de código en Swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // Obtiene el nombre del archivo XML de comentarios
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); // Combina la ruta base de la aplicación con el nombre del archivo XML
    setupAction.IncludeXmlComments(xmlPath); // Incluye los comentarios XML en la configuración de Swagger

});




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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IOrderNotificationService, OrderNotificationService>();
#endregion

builder.Services.AddTransient<IMailService, LocalMailService>();


builder.Services.Configure<AutenticacionServiceOptions>(
    builder.Configuration.GetSection(AutenticacionServiceOptions.AutenticacionService));

//  Agrega los servicios de autenticación a la aplicación y especifica que se utilizará el esquema de autenticación "Bearer" (utilizado para tokens JWT).
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options => // Configura el esquema de autenticación JWT (Bearer)
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, // Validar el emisor del token (Issuer)
        ValidateAudience = true, // Validar la audiencia del token (Audience)
        ValidateIssuerSigningKey = true, // Validar la clave de firma del emisor del token
        ValidIssuer = builder.Configuration["AutenticacionService:Issuer"], // Emisor válido del token, leído de la configuración
        ValidAudience = builder.Configuration["AutenticacionService:Audience"], // Audiencia válida del token, leída de la configuración
        //Define la clave secreta que se utiliza para firmar y validar la firma del token. Esta clave se convierte a bytes utilizando la codificación ASCII.
        //Esta clave debe ser la misma que se utilizó para firmar el token cuando se emitió.
        IssuerSigningKey = new SymmetricSecurityKey( // Clave de firma simétrica utilizada para validar el token
            Encoding.ASCII.GetBytes(builder.Configuration["AutenticacionService:SecretForKey"])) // La clave secreta utilizada para firmar el token, leída de la configuración
    });

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole(UserType.Admin.ToString()));
    options.AddPolicy("SellerPolicy", policy => policy.RequireRole(UserType.Seller.ToString()));
    options.AddPolicy("CustomerPolicy", policy => policy.RequireRole(UserType.Customer.ToString()));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
