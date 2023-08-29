
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
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

    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Set<Departamento>()
        .Include(p => p.Ciudades)
        .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(string id)
    {
        return await _context.Set<Departamento>()
        .Include(p => p.Ciudades)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Departamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Departamentos as IQueryable<Departamento>;

        if (!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.NombreDep.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.NombreDep)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);

    }

}
