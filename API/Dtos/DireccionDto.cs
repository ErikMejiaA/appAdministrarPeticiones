
namespace API.Dtos;

public class DireccionDto
{
    public int IdCodigo { get; set; }
    public string ? TipoVia { get; set; }
    public int Numero { get; set; }
    public string ? Letra { get; set; }
    public string ? SufijoCardinal { get; set; }
    public int NumeroViaSecundaria { get; set; }
    public string ? LetraViaSecundaria { get; set; }
    public string ? SufijoCards { get; set; }

    //definimos las llaves foranes
    //public string ? IdPersonaFk { get; set; }
        
}
