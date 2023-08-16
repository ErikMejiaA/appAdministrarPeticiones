
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        //Configuracion de las propiedades de la entidad

        builder.ToTable("Personas");

        builder.Property(p => p.IdCodigo)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasIndex(p => p.IdCodigo)
        .IsUnique();

        builder.Property(p => p.NombrePersona)
        .IsRequired()
        .HasMaxLength(50);

        //definimos las llaves foraneas 
        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Personas)
        .HasForeignKey( p => p.IdGeneroFk)
        .IsRequired();

        builder.HasOne(p => p.Ciudad)
        .WithMany(p => p.Personas)
        .HasForeignKey( p => p.IdCiudadFk)
        .IsRequired();

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey( p => p.IdTipoPerFk)
        .IsRequired();


    }
}
