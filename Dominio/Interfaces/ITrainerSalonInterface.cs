
using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface ITrainerSalonInterface
{
    Task<TrainerSalon> GetByIdAsync(int idTra, int idSa);
    Task<IEnumerable<TrainerSalon>> GetAllAsync();
    IEnumerable<TrainerSalon> Find(Expression<Func<TrainerSalon, bool>> expression);
    Task<(int totalRegistros, IEnumerable<TrainerSalon> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(TrainerSalon entity);
    void AddRange(IEnumerable<TrainerSalon> entities);
    void Remove(TrainerSalon entity);
    void RemoveRange(IEnumerable<TrainerSalon> entities);
    void Update(TrainerSalon entity);
        
}
