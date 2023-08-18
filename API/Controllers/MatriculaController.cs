using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MatriculaController : BaseApiController
{
    //variables definicion
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public MatriculaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<MatriculaDto>>> Get()
    {
        var matriculas = await _UnitOfWork.Matriculas.GetAllAsync();
        return this.mapper.Map<List<MatriculaDto>>(matriculas);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MatriculaDto>> Get(int id)
    {
        var matricula = await _UnitOfWork.Matriculas.GetByIdAsync(id);
        if (matricula == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MatriculaDto>(matricula);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MatriculaDto>> Post(MatriculaDto matriculaDto)
    {
        var matricula = this.mapper.Map<Matricula>(matriculaDto);
        _UnitOfWork.Matriculas.Add(matricula);
        await _UnitOfWork.SaveAsync();

        if (matricula == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<MatriculaDto>(matricula);

    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MatriculaDto>> Put(int id, [FromBody] MatriculaDto matriculaDto)
    {
        var matricula = this.mapper.Map<Matricula>(matriculaDto);
        if (matricula == null)
        {
            return NotFound();
        }
        matricula.IdCodigo = id;
        _UnitOfWork.Matriculas.Update(matricula);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<MatriculaDto>(matricula);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(int id)
    {
        var matricula = await _UnitOfWork.Matriculas.GetByIdAsync(id);
        if (matricula == null)
        {
            return NotFound();
        }
        _UnitOfWork.Matriculas.Remove(matricula);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

}
