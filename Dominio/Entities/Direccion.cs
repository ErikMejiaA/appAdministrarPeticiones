
namespace Dominio.Entities;

public class Direccion : BaseEntityB
{
    public string ? TipoVia { get; set; }
    public int Numero { get; set; }
    public string ? Letra { get; set; }
    public string ? SufijoCardinal { get; set; }
    public int NumeroViaSecundaria { get; set; }
    public string ? LetraViaSecundaria { get; set; }
    public string ? SufijoCards { get; set; }

    //definimos las llaves foranes
    public int ? IdPersonaFk { get; set; }

    //definimos una referencia 
    public Persona ? Persona { get; set; }
        
}
