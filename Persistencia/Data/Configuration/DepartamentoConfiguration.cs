
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        //Configuramos las propiedades de la entidad
        builder.ToTable("Departamentos");

        builder.Property(p => p.IdCodigo)
        .HasMaxLength(3)
        .IsRequired();

        builder.HasIndex(p => p.IdCodigo)
        .IsUnique();

        builder.Property(p => p.NombreDep)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.NombreDep)
        .IsUnique();

        //configuramaos la foranea
        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.IdPaisFK)
        .IsRequired();
        
    }
}
