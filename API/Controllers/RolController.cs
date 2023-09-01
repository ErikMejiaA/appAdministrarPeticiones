using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class RolController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public RolController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<RolDTo>>> Get()
    {
        var roles = await _UnitOfWork.Roles.GetAllAsync();
        return this.mapper.Map<List<RolDTo>>(roles);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDTo>> Get(int id)
    {
        var rol = await _UnitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return this.mapper.Map<RolDTo>(rol);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDTo>> Post(RolDTo rolDTo)
    {
        var rol = this.mapper.Map<Rol>(rolDTo);
        _UnitOfWork.Roles.Add(rol);
        await _UnitOfWork.SaveAsync();

        if (rol == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<RolDTo>(rol);

    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDTo>> Put(int id, [FromBody]RolDTo rolDTo)
    {
        var rol = this.mapper.Map<Rol>(rolDTo);
        if (rol == null)
        {
            return NotFound();
        }
        rol.IdCodigo = id;
        _UnitOfWork.Roles.Update(rol);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<RolDTo>(rol);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(int id)
    {
        var rol = await _UnitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        _UnitOfWork.Roles.Remove(rol);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

}
