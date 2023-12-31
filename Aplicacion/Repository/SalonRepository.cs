
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class SalonRepository : GenericRepositoryB<Salon>, ISalonInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public SalonRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
