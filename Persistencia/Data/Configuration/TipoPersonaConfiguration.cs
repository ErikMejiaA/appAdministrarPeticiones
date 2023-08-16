
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        //configuracion de las propiedades de la entidad
        builder.ToTable("TipoPersonas");

        builder.Property(p => p.DescripcionTipoPersona)
        .IsRequired()
        .HasMaxLength(50);
        
    }
}
