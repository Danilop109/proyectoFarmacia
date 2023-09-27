using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers
{
    public class RolController : Controller
    {
       private readonly IUnitOfWork unitOfWork;
       
               public RolController(IUnitOfWork unitOfWork)
               {
                   this.unitOfWork =unitOfWork;
               }
       
               [HttpGet]
               [ProducesResponseType(StatusCodes.Status200OK)]
               [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
               public async Task<ActionResult<IEnumerable<Rol>>> Get()
               {
                   var llamado = await unitOfWork.Rols.GetAllAsync();
                   return Ok(llamado);
               }
       
               [HttpGet("{id}")]
               [ProducesResponseType(StatusCodes.Status200OK)]
               [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
               public async Task<ActionResult> Get(int id)
               {
                   var llamado = await unitOfWork.Rols.GetByIdAsync(id);
                   return Ok(llamado);
               }
       
               [HttpPost]
               [ProducesResponseType(StatusCodes.Status201Created)]
               [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
               public async Task<ActionResult<Rol>> Post(Rol rol)
               {
                   this.unitOfWork.Rols.Add(rol);
                   await unitOfWork.SaveAsync();
                   if (rol == null)
                   {
                       return BadRequest();
                   }
                   return CreatedAtAction(nameof(Post), new { id = rol.Id }, rol);
               }
       
               [HttpPut("{id}")]
               [ProducesResponseType(StatusCodes.Status200OK)]
               [ProducesResponseType(StatusCodes.Status404NotFound)]
               [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
               public async Task<ActionResult<Rol>> Put(int id,[FromBody] Rol rol)
               {
                   if(rol == null)
                   return NotFound();
                   unitOfWork.Rols.Update(rol);
                   await unitOfWork.SaveAsync();
                   return rol;
               }
       
               [HttpDelete("{id}")]
               [ProducesResponseType(StatusCodes.Status200OK)]
               [ProducesResponseType(StatusCodes.Status404NotFound)]
               [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
               public async Task<ActionResult> Delete(int id)
               { 
                   var llamado = await unitOfWork.Rols.GetByIdAsync(id);
                   if (llamado == null){
                       return NotFound();
                   }
                   unitOfWork.Rols.Remove(llamado);
                   await unitOfWork.SaveAsync();
                   return NoContent();
               }
    }
}