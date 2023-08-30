using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class UsuarioRepository : GenericRepositoryB<Usuario>, IUsuarioInterface
{
    private readonly AppAdministraPeticionesContext _context;

    public UsuarioRepository(AppAdministraPeticionesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Set<Usuario>()
                                    .Include(u => u.Roles)
                                    .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }
}
