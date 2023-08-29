
namespace Dominio.Entities;

public class Rol : BaseEntityB
{
    public string ? Nombre { get; set; }
    public ICollection<Persona> ? Personas { get; set; }
    public ICollection<PersonaRoles> ? PersonaRoles { get; set; }

    public ICollection<Usuario> ? Usuarios { get; set; }
    public ICollection<UsuariosRoles> ? UsuariosRoles { get; set; }
      
}
