
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DireccionController : BaseApiController
{
    //variables definicion
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public DireccionController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<DireccionDto>>> Get() 
    {
        var direcciones = await _UnitOfWork.Direcciones.GetAllAsync();
        return this.mapper.Map<List<DireccionDto>>(direcciones);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DireccionDto>> Get(int id)
    {
        var direccion = await _UnitOfWork.Direcciones.GetByIdAsync(id);
        if (direccion == null) {
            return NotFound();
        }
        return this.mapper.Map<DireccionDto>(direccion);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DireccionDto>> Post(DireccionDto direccionDto)
    {
        var direccion = this.mapper.Map<Direccion>(direccionDto);
        _UnitOfWork.Direcciones.Add(direccion);
        await _UnitOfWork.SaveAsync();

        if (direccion == null) {
            return BadRequest();
        }
        return this.mapper.Map<DireccionDto>(direccion);

    }

    //METODO PUT (para editar un regitro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DireccionDto>> Put(int id, [FromBody]DireccionDto direccionDto)
    {
        var direccion = this.mapper.Map<Direccion>(direccionDto);
        if (direccion == null) {
            return NotFound();
        }
        direccion.IdCodigo = id;
        _UnitOfWork.Direcciones.Update(direccion);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<DireccionDto>(direccion);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(int id)
    {
        var direccion = await _UnitOfWork.Direcciones.GetByIdAsync(id);
        if (direccion == null) {
            return NotFound();
        }
        _UnitOfWork.Direcciones.Remove(direccion);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

        
}
