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
    public class DireccionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DireccionController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Direccion>>> Get()
        {
            var direcciones = await _unitOfWork.Direcciones.GetAllAsync();
            return Ok(direcciones);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var direccion = await _unitOfWork.Direcciones.GetByIdAsync(id);
            return Ok(direccion);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Direccion>> Post(Direccion direccion)
        {
            this._unitOfWork.Direcciones.Add(direccion);
            await _unitOfWork.SaveAsync();

        if(direccion == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = direccion.Id}, direccion);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Direccion>> Put(int id, [FromBody] Direccion direccion)
        {
        if(direccion == null)
            return NotFound();
            _unitOfWork.Direcciones.Update(direccion);
            await _unitOfWork.SaveAsync();
            return direccion;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var direccion = await _unitOfWork.Direcciones.GetByIdAsync(id);
            if(direccion == null)
            {
                return NotFound();
            }
            _unitOfWork.Direcciones.Remove(direccion);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
}