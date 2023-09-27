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
    public class PresentacionController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public PresentacionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Presentacion>>> Get()
        {
            var presentaciones = await unitOfWork.Presentaciones.GetAllAsync();
            return Ok(presentaciones);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var presentacion = await unitOfWork.Presentaciones.GetByIdAsync(id);
            return Ok(presentacion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Presentacion>> Post(Presentacion presentacion)
        {
            this.unitOfWork.Presentaciones.Add(presentacion);
            await unitOfWork.SaveAsync();
            if (presentacion == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = presentacion.Id }, presentacion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Presentacion>> Put(int id,[FromBody] Presentacion presentacion)
        {
            if(presentacion == null)
            return NotFound();
            unitOfWork.Presentaciones.Update(presentacion);
            await unitOfWork.SaveAsync();
            return presentacion;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        { 
            var presentacion = await unitOfWork.Presentaciones.GetByIdAsync(id);
            if (presentacion == null){
                return NotFound();
            }
            unitOfWork.Presentaciones.Remove(presentacion);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}