using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PaisController : BaseApiController
{
    //variables definicion
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public PaisController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<PaisDto>>> Get() 
    {
        var paises = await _UnitOfWork.Paises.GetAllAsync();
        return this.mapper.Map<List<PaisDto>>(paises);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> Get(string id)
    {
        var pais = await _UnitOfWork.Paises.GetByIdAsync(id);
        if (pais == null) {
            return NotFound();
        }
        return this.mapper.Map<PaisDto>(pais);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> Post(PaisDto paisDto)
    {
        var pais = this.mapper.Map<Pais>(paisDto);
        _UnitOfWork.Paises.Add(pais);
        await _UnitOfWork.SaveAsync();

        if (pais == null) {
            return BadRequest();
        }
        return this.mapper.Map<PaisDto>(pais);

    }

    //METODO PUT (para editar un regitro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Put(string id, [FromBody]PaisDto paisDto)
    {
        var pais = this.mapper.Map<Pais>(paisDto);
        if (pais == null) {
            return NotFound();
        }
        pais.IdCodigo = id;
        _UnitOfWork.Paises.Update(pais);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<PaisDto>(pais);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(string id)
    {
        var pais = await _UnitOfWork.Paises.GetByIdAsync(id);
        if (pais == null) {
            return NotFound();
        }
        _UnitOfWork.Paises.Remove(pais);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

}
