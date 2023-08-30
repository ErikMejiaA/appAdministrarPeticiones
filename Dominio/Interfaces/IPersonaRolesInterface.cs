using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPersonaRolesInterface 
{
    Task<PersonaRoles> GetByIdAsync(int idPerson, int idRol);
    Task<IEnumerable<PersonaRoles>> GetAllAsync();
    IEnumerable<PersonaRoles> Find(Expression<Func<PersonaRoles, bool>> expression);
    Task<(int totalRegistros, IEnumerable<PersonaRoles> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(PersonaRoles entity);
    void AddRange(IEnumerable<PersonaRoles> entities);
    void Remove(PersonaRoles entity);
    void RemoveRange(IEnumerable<PersonaRoles> entities);
    void Update(PersonaRoles entity);
}
