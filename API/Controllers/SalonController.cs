
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SalonController : BaseApiController
{
    //variables definicion
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public SalonController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<SalonDto>>> Get()
    {
        var salones = await _UnitOfWork.Salones.GetAllAsync();
        return this.mapper.Map<List<SalonDto>>(salones);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SalonDto>> Get(int id)
    {
        var salon = await _UnitOfWork.Salones.GetByIdAsync(id);
        if (salon == null)
        {
            return NotFound();
        }
        return this.mapper.Map<SalonDto>(salon);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SalonDto>> Post(SalonDto salonDto)
    {
        var salon = this.mapper.Map<Salon>(salonDto);
        _UnitOfWork.Salones.Add(salon);
        await _UnitOfWork.SaveAsync();

        if (salon == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<SalonDto>(salon);

    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalonDto>> Put(int id, [FromBody]SalonDto salonDto)
    {
        var salon = this.mapper.Map<Salon>(salonDto);
        if (salon == null)
        {
            return NotFound();
        }
        salon.IdCodigo = id;
        _UnitOfWork.Salones.Update(salon);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<SalonDto>(salon);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(int id)
    {
        var salon = await _UnitOfWork.Salones.GetByIdAsync(id);
        if (salon == null)
        {
            return NotFound();
        }
        _UnitOfWork.Salones.Remove(salon);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
        
}
