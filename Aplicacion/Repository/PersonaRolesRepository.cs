using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRolesRepository : IPersonaRolesInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public PersonaRolesRepository(AppAdministraPeticionesContext context)
    {
        _context = context;
    }

    //implementacion de los metodos de la Interfaces
    public void Add(PersonaRoles entity)
    {
        _context.Set<PersonaRoles>().Add(entity);
    }

    public void AddRange(IEnumerable<PersonaRoles> entities)
    {
        _context.Set<PersonaRoles>().AddRange(entities);
    }

    public IEnumerable<PersonaRoles> Find(Expression<Func<PersonaRoles, bool>> expression)
    {
        return _context.Set<PersonaRoles>().Where(expression);
    }

    public async Task<IEnumerable<PersonaRoles>> GetAllAsync()
    {
        return await _context.Set<PersonaRoles>().ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<PersonaRoles> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<PersonaRoles>().CountAsync();
        var registros = await _context.Set<PersonaRoles>()
                                                        .Skip((pageIndex - 1) * pageSize)
                                                        .Take(pageSize)
                                                        .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<PersonaRoles> GetByIdAsync(int idPerson, int idRol)
    {
        return await _context.Set<PersonaRoles>().FirstOrDefaultAsync(p => (p.PersonaId == idPerson && p.RolId == idRol));
    }

    public void Remove(PersonaRoles entity)
    {
        _context.Set<PersonaRoles>().Remove(entity);
    }

     public void RemoveRange(IEnumerable<PersonaRoles> entities)
    {
        _context.Set<PersonaRoles>().RemoveRange(entities);
    }

    public void Update(PersonaRoles entity)
    {
        _context.Set<PersonaRoles>().Update(entity);
    }
}
