
namespace API.Dtos;

public class SalonDto
{
    public int IdCodigo { get; set; }
    public string ? NombreSalon { get; set; }
    public int Capacidad { get; set; }

    //definimos la List<>
    //public List<MatriculaDto> ? Matriculas { get; set; }
    //public List<TrainerSalonDto> ? TrainerSalones { get; set; }
    
}
