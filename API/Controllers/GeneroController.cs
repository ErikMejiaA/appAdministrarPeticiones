using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GeneroController : BaseApiController
{
    //variables definicion
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public GeneroController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<GeneroDto>>> Get()
    {
        var generos = await _UnitOfWork.Generos.GetAllAsync();
        return this.mapper.Map<List<GeneroDto>>(generos);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GeneroDto>> Get(int id)
    {
        var genero = await _UnitOfWork.Generos.GetByIdAsync(id);
        if (genero == null)
        {
            return NotFound();
        }
        return this.mapper.Map<GeneroDto>(genero);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GeneroDto>> Post(GeneroDto generoDto)
    {
        var genero = this.mapper.Map<Genero>(generoDto);
        _UnitOfWork.Generos.Add(genero);
        await _UnitOfWork.SaveAsync();

        if (genero == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<GeneroDto>(genero);

    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody] GeneroDto generoDto)
    {
        var genero = this.mapper.Map<Genero>(generoDto);
        if (genero == null)
        {
            return NotFound();
        }
        genero.IdCodigo = id;
        _UnitOfWork.Generos.Update(genero);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<GeneroDto>(genero);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(int id)
    {
        var genero = await _UnitOfWork.Generos.GetByIdAsync(id);
        if (genero == null)
        {
            return NotFound();
        }
        _UnitOfWork.Generos.Remove(genero);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}
