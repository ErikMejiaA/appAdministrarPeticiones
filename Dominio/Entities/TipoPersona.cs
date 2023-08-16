
namespace Dominio.Entities;

public class TipoPersona : BaseEntityB
{
    public string ? DescripcionTipoPersona { get; set; }

    //definimos la ICollection<>
    public ICollection<Persona> ? Personas { get; set; }
    
        
}
