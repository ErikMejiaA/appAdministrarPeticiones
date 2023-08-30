
namespace Dominio.Entities;

public class Matricula : BaseEntityB
{
    public int ? IdPersonaFK { get; set; }
    public int IdSalonFk { get; set; }

    //definimos la referencia 
    public Persona ? Persona { get; set; }
    public Salon ? Salon { get; set; }
    
}
