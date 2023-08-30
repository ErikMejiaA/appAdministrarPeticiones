
namespace Dominio.Entities;

public class TrainerSalon
{
    //llaves foraneas primarias compuestas
    public int ? IdPerTrainerFk { get; set; }
    public int ? IdSalonFk { get; set; }

    //definimos la referencia 
    public Persona ? Persona { get; set; }
    public Salon ? Salon { get; set; }
        
}
