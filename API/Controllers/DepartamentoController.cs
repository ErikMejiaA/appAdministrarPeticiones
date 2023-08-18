
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class DepartamentoController : BaseApiController
{
    //variables 
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor
    public DepartamentoController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<DepartamentoDto>>> Get() 
    {
        var departamentos = await _UnitOfWork.Departamentos.GetAllAsync();
        return this.mapper.Map<List<DepartamentoDto>>(departamentos);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Get(string id)
    {
        var departamento = await _UnitOfWork.Departamentos.GetByIdAsync(id);
        if (departamento == null) {
            return NotFound();
        }
        return this.mapper.Map<DepartamentoDto>(departamento);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Post(DepartamentoDto departamentoDto)
    {
        var departamento = this.mapper.Map<Departamento>(departamentoDto);
        _UnitOfWork.Departamentos.Add(departamento);
        await _UnitOfWork.SaveAsync();

        if (departamento == null) {
            return BadRequest();
        }
        return this.mapper.Map<DepartamentoDto>(departamento);

    }

    //METODO PUT (para editar un regitro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Put(string id, [FromBody]DepartamentoDto departamentoDto)
    {
        var departamento = this.mapper.Map<Departamento>(departamentoDto);
        if (departamento == null) {
            return NotFound();
        }
        departamento.IdCodigo = id;
        _UnitOfWork.Departamentos.Update(departamento);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<DepartamentoDto>(departamento);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(string id)
    {
        var departamento = await _UnitOfWork.Departamentos.GetByIdAsync(id);
        if (departamento == null) {
            return NotFound();
        }
        _UnitOfWork.Departamentos.Remove(departamento);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
        
}
