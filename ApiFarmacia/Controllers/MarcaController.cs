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
    public class MarcaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarcaController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Marca>>> Get()
        {
            var marcas = await _unitOfWork.Marcas.GetAllAsync();
            return Ok(marcas);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var marca = await _unitOfWork.Marcas.GetByIdAsync(id);
            return Ok(marca);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Marca>> Post(Marca marca)
        {
            this._unitOfWork.Marcas.Add(marca);
            await _unitOfWork.SaveAsync();

        if(marca == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = marca.Id}, marca);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Marca>> Put(int id, [FromBody] Marca marca)
        {
        if(marca == null)
            return NotFound();
            _unitOfWork.Marcas.Update(marca);
            await _unitOfWork.SaveAsync();
            return marca;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var marca = await _unitOfWork.Marcas.GetByIdAsync(id);
            if(marca == null)
            {
                return NotFound();
            }
            _unitOfWork.Marcas.Remove(marca);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
}