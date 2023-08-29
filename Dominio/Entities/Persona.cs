
namespace Dominio.Entities;

public class Persona : BaseEntityB
{
    public string ? NombrePersona { get; set; }
    public string ? ApellidoPaterno { get; set; }
    public string ? ApellidoMaterno { get; set; }
    public string ? UserName { get; set; }
    public string ? Email { get; set; }
    public string ? Password { get; set; }
    
    //llaves foraneas 
    public int IdGeneroFk { get; set; }
    public string ? IdCiudadFk { get; set; }
    public int IdTipoPerFk { get; set; }

    //definimos la referencia 
    public Ciudad ? Ciudad { get; set; }
    public Genero ? Genero { get; set; }
    public TipoPersona ? TipoPersona { get; set; }

    //definimos la ICollection<>
    public ICollection<Matricula> ? Matriculas {get; set; }
    public ICollection<TrainerSalon> ? TrainerSalones { get; set; }

    public ICollection<Direccion> ? Direcciones { get; set; }
    public ICollection<Rol> ? Roles { get; set; } = new HashSet<Rol>();
    public ICollection<PersonaRoles> ? PersonaRoles { get; set; }

            
}
