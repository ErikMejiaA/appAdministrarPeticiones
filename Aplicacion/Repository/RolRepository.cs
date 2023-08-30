using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class RolRepository : GenericRepositoryB<Rol>, IRolInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public RolRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
}
