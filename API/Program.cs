using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors(); //Configura las Cors para los Endpoint

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

app.UseAuthorization();

app.MapControllers();

app.Run();
