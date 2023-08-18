using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CiudadController : BaseApiController
{
    //variables 
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor
    public CiudadController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<CiudadDto>>> Get() 
    {
        var ciudades = await _UnitOfWork.Paises.GetAllAsync();
        return this.mapper.Map<List<CiudadDto>>(ciudades);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> Get(string id)
    {
        var ciudad = await _UnitOfWork.Paises.GetByIdAsync(id);
        if (ciudad == null) {
            return NotFound();
        }
        return this.mapper.Map<CiudadDto>(ciudad);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> Post(CiudadDto ciudadDto)
    {
        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        _UnitOfWork.Ciudades.Add(ciudad);
        await _UnitOfWork.SaveAsync();

        if (ciudad == null) {
            return BadRequest();
        }
        return this.mapper.Map<CiudadDto>(ciudad);

    }

    //METODO PUT (para editar un regitro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadDto>> Put(string id, [FromBody]CiudadDto ciudadDto)
    {
        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        if (ciudad == null) {
            return NotFound();
        }
        ciudad.IdCodigo = id;
        _UnitOfWork.Ciudades.Update(ciudad);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<CiudadDto>(ciudad);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(string id)
    {
        var ciudad = await _UnitOfWork.Ciudades.GetByIdAsync(id);
        if (ciudad == null) {
            return NotFound();
        }
        _UnitOfWork.Ciudades.Remove(ciudad);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}
