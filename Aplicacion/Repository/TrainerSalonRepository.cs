
using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class TrainerSalonRepository : ITrainerSalonInterface
{
    //creamos la variable de context
    private readonly AppAdministraPeticionesContext _context;

    //creacion del constructor 
    public TrainerSalonRepository(AppAdministraPeticionesContext context)
    {
        _context = context;
    }

    //implementacion de los metodos de la Interfaces
    public void Add(TrainerSalon entity)
    {
        _context.Set<TrainerSalon>().Add(entity);
    }

    public void AddRange(IEnumerable<TrainerSalon> entities)
    {
        _context.Set<TrainerSalon>().AddRange(entities);
    }

    public IEnumerable<TrainerSalon> Find(Expression<Func<TrainerSalon, bool>> expression)
    {
        return _context.Set<TrainerSalon>().Where(expression);
    }

    public async Task<IEnumerable<TrainerSalon>> GetAllAsync()
    {
        return await _context.Set<TrainerSalon>().ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<TrainerSalon> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<TrainerSalon>().CountAsync();
        var registros = await _context.Set<TrainerSalon>()
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<TrainerSalon> GetByIdAsync(int idTra, int idSa)
    {
        return await _context.Set<TrainerSalon>().FirstOrDefaultAsync(p => (p.IdPerTrainerFk == idTra && p.IdSalonFk == idSa));
    }

    public void Remove(TrainerSalon entity)
    {
        _context.Set<TrainerSalon>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TrainerSalon> entities)
    {
        _context.Set<TrainerSalon>().RemoveRange(entities);
    }

    public void Update(TrainerSalon entity)
    {
        _context.Set<TrainerSalon>().Update(entity);
    }
}
