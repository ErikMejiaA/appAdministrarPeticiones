
using API.Dtos;

namespace API.Services;
public interface IUserServiceInterface
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<DatosUsuarioDto> GetTokenAsync(LoginDto model);
    Task<DatosUsuarioDto> GetTokenAsync(AuthenticationTokenResultDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
        
}
