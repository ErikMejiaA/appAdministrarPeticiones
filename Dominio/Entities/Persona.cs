
namespace Dominio.Entities;

public class Persona : BaseEntityA
{
    public string ? NombrePersona { get; set; }

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

            
}
