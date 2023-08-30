
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
        .IsRequired();

        builder.HasIndex(p => p.IdCodigo)
        .IsUnique();

        builder.Property(p => p.NombrePersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ApellidoPaterno)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ApellidoMaterno)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.UserName)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Password)
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

        //se define la configuracion de la entidad PersonaRoles
        builder
        .HasMany(p => p.Roles)
        .WithMany(p => p.Personas)
        .UsingEntity<PersonaRoles> (
            j => j
                .HasOne(p => p.Rol)
                .WithMany(p => p.PersonaRoles)
                .HasForeignKey(p => p.RolId),

            j => j
                .HasOne(p => p.Persona)
                .WithMany(p => p.PersonaRoles)
                .HasForeignKey(p => p.PersonaId),

            j => 
                {
                    j.HasKey(p => new { p.PersonaId, p.RolId});
                }
        );

    }
}
