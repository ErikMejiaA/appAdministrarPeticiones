
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        //configurar las propiedades de la entidad
        builder.ToTable("Matriculas");

        //definimos las Foraneas
        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Matriculas)
        .HasForeignKey(p => p.IdPersonaFK)
        .IsRequired();

        builder.HasOne(p => p.Salon)
        .WithMany(p => p.Matriculas)
        .HasForeignKey(p => p.IdSalonFk)
        .IsRequired();
    }
}
