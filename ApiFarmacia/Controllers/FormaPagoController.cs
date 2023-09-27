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
    public class FormaPagoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormaPagoController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<FormaPago>>> Get()
        {
            var formaPagos = await _unitOfWork.FormaPagos.GetAllAsync();
            return Ok(formaPagos);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var formaPago = await _unitOfWork.FormaPagos.GetByIdAsync(id);
            return Ok(formaPago);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<FormaPago>> Post(FormaPago formaPago)
        {
            this._unitOfWork.FormaPagos.Add(formaPago);
            await _unitOfWork.SaveAsync();

        if(formaPago == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = formaPago.Id}, formaPago);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<FormaPago>> Put(int id, [FromBody] FormaPago formaPago)
        {
        if(formaPago == null)
            return NotFound();
            _unitOfWork.FormaPagos.Update(formaPago);
            await _unitOfWork.SaveAsync();
            return formaPago;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var formaPago = await _unitOfWork.FormaPagos.GetByIdAsync(id);
            if(formaPago == null)
            {
                return NotFound();
            }
            _unitOfWork.FormaPagos.Remove(formaPago);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
}