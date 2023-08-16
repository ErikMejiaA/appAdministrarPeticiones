
using System.Data.Common;
using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class AppAdministraPeticionesContext : DbContext
{
    public AppAdministraPeticionesContext(DbContextOptions<AppAdministraPeticionesContext> options) : base(options)
    {

    }

    //se crean los DbSet<> de las entidades
    public DbSet<Ciudad> ? Ciudades { get; set; }
    public DbSet<Departamento>  ? Departamentos { get; set; }
    public DbSet<Genero> ? Generos { get; set; }
    public DbSet<Matricula> ? Matriculas { get; set; }
    public DbSet<Pais> ? Paises { get; set; }
    public DbSet<Persona> ? Personas { get; set; }
    public DbSet<Salon> ? Salones { get; set; }
    public DbSet<TipoPersona> ? TipoPersonas { get; set; }
    public DbSet<TrainerSalon> ? TrainerSalones { get; set; }
    public DbSet<Direccion> ? Direcciones { get; set; }


    //metodo para cargar de forma automatica las entidades y configuraciones de estas en la base de datos creada
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //definimos las llaves primarias campuestas de la entida ProductoPersona. de una relacion de muchos a muchos
        modelBuilder.Entity<TrainerSalon>().HasKey(p => new {p.IdPerTrainerFk, p.IdSalonFk});

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    internal void SaveAsync()
    {
        throw new NotImplementedException();
    }
}
