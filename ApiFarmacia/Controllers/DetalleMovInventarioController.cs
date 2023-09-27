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
  
    public class DetalleMovInventarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetalleMovInventarioController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<DetalleMovInventario>>> Get()
        {
            var detalleMovInventarios = await _unitOfWork.DetalleMovInventarios.GetAllAsync();
            return Ok(detalleMovInventarios);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var detalleMovInventario = await _unitOfWork.DetalleMovInventarios.GetByIdAsync(id);
            return Ok(detalleMovInventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DetalleMovInventario>> Post(DetalleMovInventario detalleMovInventario)
        {
            this._unitOfWork.DetalleMovInventarios.Add(detalleMovInventario);
            await _unitOfWork.SaveAsync();

        if(detalleMovInventario == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = detalleMovInventario.Id}, detalleMovInventario);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DetalleMovInventario>> Put(int id, [FromBody] DetalleMovInventario detalleMovInventario)
        {
        if(detalleMovInventario == null)
            return NotFound();
            _unitOfWork.DetalleMovInventarios.Update(detalleMovInventario);
            await _unitOfWork.SaveAsync();
            return detalleMovInventario;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var detalleMovInventario = await _unitOfWork.DetalleMovInventarios.GetByIdAsync(id);
            if(detalleMovInventario == null)
            {
                return NotFound();
            }
            _unitOfWork.DetalleMovInventarios.Remove(detalleMovInventario);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
    }