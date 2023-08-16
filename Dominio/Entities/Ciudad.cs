
namespace Dominio.Entities;

public class Ciudad : BaseEntityA
{
    public string ? NombreCiudad { get; set; }
    public string ? IdDepFk { get; set; }

    //definimos la referencia 
    public Departamento ? Departamento { get; set; }

    //definimos la ICollection<>
    public ICollection<Persona> ? Personas { get; set; }

        
}
