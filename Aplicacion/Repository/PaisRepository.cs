
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository : GenericRepositoryA<Pais>, IPaisInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public PaisRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
