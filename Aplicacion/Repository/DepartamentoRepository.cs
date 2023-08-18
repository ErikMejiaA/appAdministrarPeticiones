
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class DepartamentoRepository : GenericRepositoryA<Departamento>, IDepartamentoInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public DepartamentoRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

}
