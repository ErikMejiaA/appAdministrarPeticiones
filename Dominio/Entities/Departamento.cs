
namespace Dominio.Entities;

public class Departamento : BaseEntityA
{
    public string ? NombreDep { get; set; }
    public string ? IdPaisFK { get; set; }

    //deinimos la referencia 
    public Pais ? Pais { get; set; }
    
    //definimos la ICollection<>
    public ICollection<Ciudad> ? Ciudades { get; set; }
    
}
