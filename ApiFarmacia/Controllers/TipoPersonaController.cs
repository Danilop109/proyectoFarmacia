using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiFarmacia.Dtos;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers;
public class TipoPersonaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
    {
        var llamado = await unitOfWork.TipoPersonas.GetAllAsync();
        return _mapper.Map<List<TipoPersonaDto>>(llamado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersonaDto>> Get(int id)
    {
        var tipoPersona = await unitOfWork.TipoPersonas.GetByIdAsync(id);
        if(tipoPersona == null)
        {
            return NotFound();
        }
        return _mapper.Map<TipoPersonaDto>(tipoPersona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto tipoPersonaDto)
    {
        var tipoPersona = _mapper.Map<TipoPersona>(tipoPersonaDto);
        this.unitOfWork.TipoPersonas.Add(tipoPersona);
        await unitOfWork.SaveAsync();
        if (tipoPersona == null)
        {
            return BadRequest();
        }
        tipoPersonaDto.Id = tipoPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoPersonaDto.Id }, tipoPersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto tipoPersonaDto)
    {
        if (tipoPersonaDto == null)
        {
            return NotFound();
        }
        var tipoPersona = this._mapper.Map<TipoPersona>(tipoPersonaDto);
        unitOfWork.TipoPersonas.Update(tipoPersona);
        await unitOfWork.SaveAsync();
        return tipoPersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Delete(int id)
    {
        var llamado = await unitOfWork.TipoPersonas.GetByIdAsync(id);
        if (llamado == null)
        {
            return NotFound();
        }
        unitOfWork.TipoPersonas.Remove(llamado);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
