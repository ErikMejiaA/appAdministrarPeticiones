
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
        ISalonInterface Salones { get; }
        ITipoPersonaInterface TipoPersonas { get; }
        ITrainerSalonInterface TrainerSalones { get; }

        Task<int> SaveAsync();
    }
