
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWorkInterface, IDisposable
{
    //variable de contexto
    private readonly AppAdministraPeticionesContext _context;

    //generamos las variables de vcada repositoryo creado
    private CiudadRepository ? _ciudades;
    private DepartamentoRepository ? _departamentos;
    private DireccionRepository ? _direcciones;
    private GeneroRepository ? _generos;
    private MatriculaRepository ? _matriculas;
    private PaisRepository ? _paises;
    private PersonaRepository ? _personas;
    private SalonRepository ? _salones;
    private TipoPersonaRepository ? _tipoPersonas;
    private TrainerSalonRepository ? _trainerSalones;

    public UnitOfWork(AppAdministraPeticionesContext context)
    {
        _context = context;
    }

    //implementamos cada uno de los metodos de las interfaces

    public ICiudadInterface Ciudades
    {
        get 
        {
            if (_ciudades == null){
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }

    public IDepartamentoInterface Departamentos
    {
        get
        {
            if (_departamentos == null) {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }

    public IDireccionInterface Direcciones
    {
        get
        {
            if (_direcciones == null) {
                _direcciones = new DireccionRepository(_context);
            }
            return _direcciones;
        }
    }

    public IGeneroInterface Generos
    {
        get
        {
            if (_generos == null) {
                _generos = new GeneroRepository(_context);
            }
            return _generos;
        }
    }

    public IMatriculaInterface Matriculas
    {
        get
        {
            if (_matriculas == null) { 
                _matriculas = new MatriculaRepository(_context);
            }
            return _matriculas;
        }
    }

    public IPaisInterface Paises
    {
        get
        {
            if (_paises == null) { 
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public IPersonaInterface Personas
    {
        get
        {
            if (_personas == null) {
                _personas = new PersonaRepository(_context);
            }
            return _personas;
        }
    }

    public ISalonInterface Salones
    {
        get
        {
            if (_salones == null) {
                _salones = new SalonRepository(_context);
            }
            return _salones;
        }
    }

    public ITipoPersonaInterface TipoPersonas
    {
        get
        {
            if (_tipoPersonas == null) {
                _tipoPersonas = new TipoPersonaRepository(_context);
            }
            return _tipoPersonas;
        }
    }

    public ITrainerSalonInterface TrainerSalones
    {
        get
        {
            if (_trainerSalones == null) {
                _trainerSalones = new TrainerSalonRepository(_context);
            }
            return _trainerSalones;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
