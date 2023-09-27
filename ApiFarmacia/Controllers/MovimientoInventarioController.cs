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
    
    public class MovimientoInventarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovimientoInventarioController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<MovimientoInventario>>> Get()
        {
            var movimientoInventario = await _unitOfWork.MovimientoInventarios.GetAllAsync();
            return Ok(movimientoInventario);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var movimientoInventario = await _unitOfWork.MovimientoInventarios.GetByIdAsync(id);
            return Ok(movimientoInventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MovimientoInventario>> Post(MovimientoInventario movimientoInventario)
        {
            this._unitOfWork.MovimientoInventarios.Add(movimientoInventario);
            await _unitOfWork.SaveAsync();

        if(movimientoInventario == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = movimientoInventario.Id}, movimientoInventario);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MovimientoInventario>> Put(int id, [FromBody] MovimientoInventario movimientoInventario)
        {
        if(movimientoInventario == null)
            return NotFound();
            _unitOfWork.MovimientoInventarios.Update(movimientoInventario);
            await _unitOfWork.SaveAsync();
            return movimientoInventario;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var movimientoInventario = await _unitOfWork.MovimientoInventarios.GetByIdAsync(id);
            if(movimientoInventario == null)
            {
                return NotFound();
            }
            _unitOfWork.MovimientoInventarios.Remove(movimientoInventario);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
}