
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PersonaController : BaseApiController
{
    //variables 
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor
    public PersonaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<PersonaDto>>> Get() 
    {
        var personas = await _UnitOfWork.Personas.GetAllAsync();
        return this.mapper.Map<List<PersonaDto>>(personas);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Get(string id)
    {
        var persona = await _UnitOfWork.Personas.GetByIdAsync(id);
        if (persona == null) {
            return NotFound();
        }
        return this.mapper.Map<PersonaDto>(persona);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Post(PersonaDto personaDto)
    {
        var persona = this.mapper.Map<Persona>(personaDto);
        _UnitOfWork.Personas.Add(persona);
        await _UnitOfWork.SaveAsync();

        if (persona == null) {
            return BadRequest();
        }
        return this.mapper.Map<PersonaDto>(persona);

    }

    //METODO PUT (para editar un regitro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> Put(string id, [FromBody]PersonaDto personaDto)
    {
        var persona = this.mapper.Map<Persona>(personaDto);
        if (persona == null) {
            return NotFound();
        }
        persona.IdCodigo = id;
        _UnitOfWork.Personas.Update(persona);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<PersonaDto>(persona);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(string id)
    {
        var persona = await _UnitOfWork.Personas.GetByIdAsync(id);
        if (persona == null) {
            return NotFound();
        }
        _UnitOfWork.Personas.Remove(persona);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }   
}
