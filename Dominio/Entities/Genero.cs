
namespace Dominio.Entities;

public class Genero : BaseEntityB
{
    public string ? NombreGenero { get; set; }

    //definimos la ICollection<>
    public ICollection<Persona> ? Personas { get; set; }
    
       
}
