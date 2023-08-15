
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class AppAdministraPeticionesContext : DbContext
{
    public AppAdministraPeticionesContext(DbContextOptions<AppAdministraPeticionesContext> options) : base(options)
    {

    }

    //se crean los DbSet<> de las entidades



    //metodo para cargar de forma automatica las entidades y configuraciones de estas en la base de datos creada
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //definimos las llaves primarias campuestas de la entida ProductoPersona. de una relacion de muchos a muchos
        //modelBuilder.Entity<ProductoPersona>().HasKey(p => new {p.IdProducto, p.IdPersona});

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    internal void SaveAsync()
    {
        throw new NotImplementedException();
    }
}
