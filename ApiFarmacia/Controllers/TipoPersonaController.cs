using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers;
public class TipoPersonaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;

    public TipoPersonaController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoPersona>>> Get()
    {
        var llamado = await unitOfWork.TipoPersonas.GetAllAsync();
        return Ok(llamado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Get(int id)
    {
        var llamado = await unitOfWork.TipoPersonas.GetByIdAsync(id);
        return Ok(llamado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersona>> Post(TipoPersona tipoPersona)
    {
        this.unitOfWork.TipoPersonas.Add(tipoPersona);
        await unitOfWork.SaveAsync();
        if (tipoPersona == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = tipoPersona.Id }, tipoPersona);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersona>> Put(int id, [FromBody] TipoPersona tipoPersona)
    {
        if (tipoPersona == null)
            return NotFound();
        unitOfWork.TipoPersonas.Update(tipoPersona);
        await unitOfWork.SaveAsync();
        return tipoPersona;
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
