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
    public class TipoContactoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        
                public TipoContactoController(IUnitOfWork unitOfWork)
                {
                    this.unitOfWork =unitOfWork;
                }
        
                [HttpGet]
                [ProducesResponseType(StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
                public async Task<ActionResult<IEnumerable<TipoContacto>>> Get()
                {
                    var llamado = await unitOfWork.TipoContactos.GetAllAsync();
                    return Ok(llamado);
                }
        
                [HttpGet("{id}")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
                public async Task<ActionResult> Get(int id)
                {
                    var llamado = await unitOfWork.TipoContactos.GetByIdAsync(id);
                    return Ok(llamado);
                }
        
                [HttpPost]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
                public async Task<ActionResult<TipoContacto>> Post(TipoContacto tipoContacto)
                {
                    this.unitOfWork.TipoContactos.Add(tipoContacto);
                    await unitOfWork.SaveAsync();
                    if (tipoContacto == null)
                    {
                        return BadRequest();
                    }
                    return CreatedAtAction(nameof(Post), new { id = tipoContacto.Id }, tipoContacto);
                }
        
                [HttpPut("{id}")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status404NotFound)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
                public async Task<ActionResult<TipoContacto>> Put(int id,[FromBody] TipoContacto tipoContacto)
                {
                    if(tipoContacto == null)
                    return NotFound();
                    unitOfWork.TipoContactos.Update(tipoContacto);
                    await unitOfWork.SaveAsync();
                    return tipoContacto;
                }
        
                [HttpDelete("{id}")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status404NotFound)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
                public async Task<IActionResult> Delete(int id)
                { 
                    var llamado = await unitOfWork.TipoContactos.GetByIdAsync(id);
                    if (llamado == null){
                        return NotFound();
                    }
                    unitOfWork.TipoContactos.Remove(llamado);
                    await unitOfWork.SaveAsync();
                    return NoContent();
                }
    }
