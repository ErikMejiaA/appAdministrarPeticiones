
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class SalonConfiguration : IEntityTypeConfiguration<Salon>
{
    public void Configure(EntityTypeBuilder<Salon> builder)
    {
        //configuracion de las propiedades de las entidades
        builder.ToTable("Salones");

        builder.Property(p => p.NombreSalon)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.NombreSalon)
        .IsUnique();

        builder.Property(p => p.Capacidad)
        .HasColumnType("int")
        .IsRequired();
        
    }
}
