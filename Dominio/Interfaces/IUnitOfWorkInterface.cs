
namespace Dominio.Interfaces;

    public interface IUnitOfWorkInterface
    {
        //implementamos cada unas de las interfaces creadas para cada entidad 
        ICiudadInterface Ciudades { get; }
        IDepartamentoInterface Departamentos { get; }
        IDireccionInterface Direcciones { get; }
        IGeneroInterface Generos { get; }
        IMatriculaInterface Matriculas { get; }
        IPaisInterface Paises { get; }
        IPersonaInterface Personas { get; }
        IRolInterface Roles { get; }
        ISalonInterface Salones { get; }
        ITipoPersonaInterface TipoPersonas { get; }
        IPersonaRolesInterface PersonaRoles { get; }
        ITrainerSalonInterface TrainerSalones { get; }
        IUsuarioInterface Usuarios { get; }
        IUsuariosRolesInterface UsuariosRoles { get; }
        

        Task<int> SaveAsync();
    }
