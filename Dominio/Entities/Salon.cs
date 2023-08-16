
namespace Dominio.Entities;

public class Salon : BaseEntityB
{
    public string ? NombreSalon { get; set; }
    public int Capacidad { get; set; }

    //definimos la ICollection<>
    public ICollection<Matricula> ? Matriculas { get; set; }
    public ICollection<TrainerSalon> ? TrainerSalones { get; set; }
    
        
}
