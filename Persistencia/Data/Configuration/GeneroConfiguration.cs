
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        //configuracion de las propiedades de la entidad
        builder.ToTable("Generos");

        builder.Property(p => p.NombreGenero)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.NombreGenero)
        .IsUnique();
    }
}