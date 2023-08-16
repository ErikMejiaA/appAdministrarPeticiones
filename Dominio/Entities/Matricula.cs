
namespace Dominio.Entities;

public class Matricula : BaseEntityB
{
    public string ? IdPersonaFK { get; set; }
    public int IdSalonFk { get; set; }

    //definimos la referencia 
    public Persona ? Persona { get; set; }
    public Salon ? Salon { get; set; }
    
}
