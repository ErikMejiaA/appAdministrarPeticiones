
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class MatriculaRepository : GenericRepositoryB<Matricula>, IMatriculaInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public MatriculaRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
}
