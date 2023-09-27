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
   
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaisController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            var pais = await _unitOfWork.Paises.GetAllAsync();
            return Ok(pais);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var paises = await _unitOfWork.Paises.GetByIdAsync(id);
            return Ok(paises);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Post(Pais pais)
        {
            this._unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();

        if(pais == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = pais.Id}, pais);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Put(int id, [FromBody]Pais pais)
        {
        if(pais == null)
            return NotFound();
            _unitOfWork.Paises.Update(pais);
            await _unitOfWork.SaveAsync();
            return pais;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if(pais == null)
            {
                return NotFound();
            }
            _unitOfWork.Paises.Remove(pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
 
}