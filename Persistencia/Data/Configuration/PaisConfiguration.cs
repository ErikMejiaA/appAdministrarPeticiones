
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        //Configuracion de las propiedades de la entidad
        builder.ToTable("Paises");

        builder.Property(p => p.IdCodigo)
        .IsRequired()
        .HasMaxLength(3);

        builder.HasIndex(p => p.IdCodigo)
        .IsUnique();

        builder.Property(p => p.NombrePais)
        .IsRequired()
        .HasMaxLength(50);

         builder.HasIndex(p => p.NombrePais)
        .IsUnique();


    }
}
