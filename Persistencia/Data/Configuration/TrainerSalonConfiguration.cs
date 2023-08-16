
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TrainerSalonConfiguration : IEntityTypeConfiguration<TrainerSalon>
{
    public void Configure(EntityTypeBuilder<TrainerSalon> builder)
    {
        //Configuramos las propiedades de la entidad
        builder.ToTable("TrainerSalones");

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.TrainerSalones)
        .HasForeignKey(p => p.IdPerTrainerFk)
        .IsRequired();

        builder.HasOne(p => p.Salon)
        .WithMany(p => p.TrainerSalones)
        .HasForeignKey(p => p.IdSalonFk)
        .IsRequired();
    }
}
