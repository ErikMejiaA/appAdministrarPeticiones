
using Dominio.Entities;
using Dominio.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class GenericRepositoryA<T> : IGenericInterfaceA<T> where T : BaseEntityA
{
    private readonly AppAdministraPeticionesContext _context;

    public GenericRepositoryA(AppAdministraPeticionesContext context)
    {
        _context = context;
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<T>().CountAsync();
        var registros = await _context.Set<T>()
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

        return (totalRegistros, registros);

    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}