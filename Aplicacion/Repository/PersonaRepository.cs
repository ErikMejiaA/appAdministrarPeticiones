
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepositoryA<Persona>, IPersonaInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public PersonaRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
