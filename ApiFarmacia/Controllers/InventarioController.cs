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
   
    public class InventarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventarioController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Inventario>>> Get()
        {
            var inventarios = await _unitOfWork.Inventarios.GetAllAsync();
            return Ok(inventarios);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
            return Ok(inventario);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Inventario>> Post(Inventario inventario)
        {
            this._unitOfWork.Inventarios.Add(inventario);
            await _unitOfWork.SaveAsync();

        if(inventario == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = inventario.Id}, inventario);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Inventario>> Put(int id, [FromBody] Inventario inventario)
        {
        if(inventario == null)
            return NotFound();
            _unitOfWork.Inventarios.Update(inventario);
            await _unitOfWork.SaveAsync();
            return inventario;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
            if(inventario == null)
            {
                return NotFound();
            }
            _unitOfWork.Inventarios.Remove(inventario);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
    }