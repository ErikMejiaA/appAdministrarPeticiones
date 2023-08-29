namespace Dominio.Entities;
public class PersonaRoles
{
    public int ? PersonaId { get; set; }
    public Persona ? Persona { get; set; }
    public int ? RolId { get; set; }
    public Rol ? Rol { get; set; }       
}
