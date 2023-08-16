
namespace Dominio.Entities;

public class Pais : BaseEntityA
{
    public string ? NombrePais { get; set; }

    //definimos la ICollection<>
    public ICollection<Departamento> ? Departamentos { get; set; }
    
        
}
