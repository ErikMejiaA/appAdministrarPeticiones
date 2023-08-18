
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class GeneroRepository : GenericRepositoryB<Genero>, IGeneroInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public GeneroRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
