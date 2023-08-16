
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        //Configuracion de las propiedades de la entidad
        builder.ToTable("Ciudades");

        builder.Property(p => p.IdCodigo)
        .IsRequired()
        .HasMaxLength(3);

        builder.HasIndex(p => p.IdCodigo)
        .IsUnique();

        builder.Property(p => p.NombreCiudad)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.NombreCiudad)
        .IsUnique();

        //configuracion de la foranea
        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Ciudades)
        .HasForeignKey(p => p.IdDepFk)
        .IsRequired();
    }
}
