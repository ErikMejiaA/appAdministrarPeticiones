
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoPersonaController : BaseApiController
{
    //variables definicion
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public TipoPersonaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<TipoPersonaDto>>> Get()
    {
        var tipoPersonas = await _UnitOfWork.TipoPersonas.GetAllAsync();
        return this.mapper.Map<List<TipoPersonaDto>>(tipoPersonas);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersonaDto>> Get(int id)
    {
        var tipoPersona = await _UnitOfWork.TipoPersonas.GetByIdAsync(id);
        if (tipoPersona == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoPersonaDto>(tipoPersona);
    }

    //METODO POST (para enviar informacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersonaDto>> Post(TipoPersonaDto tipoPersonaDto)
    {
        var tipoPersona = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        _UnitOfWork.TipoPersonas.Add(tipoPersona);
        await _UnitOfWork.SaveAsync();

        if (tipoPersona == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TipoPersonaDto>(tipoPersona);

    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto tipoPersonaDto)
    {
        var tipoPersona = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        if (tipoPersona == null)
        {
            return NotFound();
        }
        tipoPersona.IdCodigo = id;
        _UnitOfWork.TipoPersonas.Update(tipoPersona);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<TipoPersonaDto>(tipoPersona);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(int id)
    {
        var tipoPersona = await _UnitOfWork.TipoPersonas.GetByIdAsync(id);
        if (tipoPersona == null)
        {
            return NotFound();
        }
        _UnitOfWork.TipoPersonas.Remove(tipoPersona);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
        
}
