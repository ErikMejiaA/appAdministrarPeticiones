
namespace Dominio.Entities;

public class TrainerSalon
{
    public string ? IdPerTrainerFk { get; set; }
    public int IdSalonFk { get; set; }

    //definimos la referencia 
    public Persona ? Persona { get; set; }
    public Salon ? Salon { get; set; }
        
}
