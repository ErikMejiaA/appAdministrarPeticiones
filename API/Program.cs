using System.Reflection;
using System.Text;
using API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors(); //Configura las Cors para los Endpoint
builder.Services.AddApplicationServices(); //definir las interfaces y repositorios
builder.Services.AddJwt(builder.Configuration); //definir los parametros del JWT para añadir 
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly()); //habilitar el AutoMapper

//crear la conexion a la base de datos 
builder.Services.AddDbContext<AppAdministraPeticionesContext>(optionsBuilder =>
{
   string? connectionString = builder.Configuration.GetConnectionString("ConexMysql");
   optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   var loggerFactory = services.GetRequiredService<ILoggerFactory>();
   try
    {
        var context = services.GetRequiredService<AppAdministraPeticionesContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrió un error durante la migración");
    }
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//server = 192.168.128.209; user = apolo; password = Apo1oC@mp3r;
//server = localhost; user = root; password = 123456789;
//dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
//dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.2
