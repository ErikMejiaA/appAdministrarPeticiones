
namespace Dominio.Entities;

public class Persona : BaseEntityA
{
    public string ? NombrePersona { get; set; }

    //llaves foraneas 
    public int IdGeneroFk { get; set; }
    public int IdCiudadFk { get; set; }
    public int IdTipoPerFk { get; set; }
            
}
