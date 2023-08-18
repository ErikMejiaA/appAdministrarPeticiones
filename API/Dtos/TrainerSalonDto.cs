
namespace API.Dtos;

public class TrainerSalonDto
{
    //llaves foraneas primarias compuestas
    public string ? IdPerTrainerFk { get; set; }
    public int IdSalonFk { get; set; }        
}
