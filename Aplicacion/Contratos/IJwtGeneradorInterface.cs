using Dominio.Entities;

namespace Aplicacion.Contratos;
public interface IJwtGeneradorInterface
{
    string ? CrearToken(Usuario usuario);
        
}
