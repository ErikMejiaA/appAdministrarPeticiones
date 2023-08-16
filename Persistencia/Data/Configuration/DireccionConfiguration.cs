
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        //configuracion de las propiedades de las entidades
        builder.ToTable("Direcciones");

        builder.Property(p => p.TipoVia)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(p => p.Numero)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Letra)
        .IsRequired()
        .HasMaxLength(1);

        builder.Property(p => p.SufijoCardinal)
        .IsRequired()
        .HasMaxLength(30);

        builder.Property(p => p.NumeroViaSecundaria)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.LetraViaSecundaria)
        .IsRequired()
        .HasMaxLength(1);

        builder.Property(p => p .SufijoCards)
        .IsRequired()
        .HasMaxLength(30);

        //definimos las foraneas 
        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Direcciones)
        .HasForeignKey(p => p.IdPersonaFk)
        .IsRequired();

    }
}
