
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TrainerSalonController : BaseApiController
{
     //variables definicion
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public TrainerSalonController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<TrainerSalonDto>>> Get()
    {
        var trainerSalones = await _UnitOfWork.TrainerSalones.GetAllAsync();
        return this.mapper.Map<List<TrainerSalonDto>>(trainerSalones);

    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{idTra}/{idSa}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainerSalonDto>> Get(string idTra, int idSa)
    {
        var trainerSalon = await _UnitOfWork.TrainerSalones.GetByIdAsync(idTra, idSa);
        if (trainerSalon == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TrainerSalonDto>(trainerSalon);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainerSalonDto>> Post(TrainerSalonDto trainerSalonDto)
    {
        var trainerSalon = this.mapper.Map<TrainerSalon>(trainerSalonDto);
        _UnitOfWork.TrainerSalones.Add(trainerSalon);
        await _UnitOfWork.SaveAsync();

        if (trainerSalon == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TrainerSalonDto>(trainerSalon);

    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{idTra}/{idSa}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TrainerSalonDto>> Put(string idTra, int idSa, [FromBody] TrainerSalonDto trainerSalonDto)
    {
        var trainerSalon = this.mapper.Map<TrainerSalon>(trainerSalonDto);
        if (trainerSalon == null)
        {
            return NotFound();
        }
        trainerSalon.IdPerTrainerFk = idTra;
        trainerSalon.IdSalonFk = idSa;
        _UnitOfWork.TrainerSalones.Update(trainerSalon);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<TrainerSalonDto>(trainerSalon);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{idTra}/{idSa}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult> Delete(string idTra, int idSa)
    {
        var trainerSalon = await _UnitOfWork.TrainerSalones.GetByIdAsync(idTra, idSa);
        if (trainerSalon == null)
        {
            return NotFound();
        }
        _UnitOfWork.TrainerSalones.Remove(trainerSalon);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}
