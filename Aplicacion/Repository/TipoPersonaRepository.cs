
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class TipoPersonaRepository : GenericRepositoryB<TipoPersona>, ITipoPersonaInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public TipoPersonaRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
