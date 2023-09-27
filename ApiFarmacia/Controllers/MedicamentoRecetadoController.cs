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
 
    public class MedicamentoRecetadoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicamentoRecetadoController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<MedicamentoRecetado>>> Get()
        {
            var medicamentoRecetados = await _unitOfWork.MedicamentoRecetados.GetAllAsync();
            return Ok(medicamentoRecetados);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var medicamentosRecetados = await _unitOfWork.MedicamentoRecetados.GetByIdAsync(id);
            return Ok(medicamentosRecetados);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MedicamentoRecetado>> Post(MedicamentoRecetado medicamentoRecetado)
        {
            this._unitOfWork.MedicamentoRecetados.Add(medicamentoRecetado);
            await _unitOfWork.SaveAsync();

        if(medicamentoRecetado == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = medicamentoRecetado.Id}, medicamentoRecetado);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MedicamentoRecetado>> Put(int id, [FromBody] MedicamentoRecetado medicamentoRecetado)
        {
        if(medicamentoRecetado == null)
            return NotFound();
            _unitOfWork.MedicamentoRecetados.Update(medicamentoRecetado);
            await _unitOfWork.SaveAsync();
            return medicamentoRecetado;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var medicamentoRecetado = await _unitOfWork.MedicamentoRecetados.GetByIdAsync(id);
            if(medicamentoRecetado == null)
            {
                return NotFound();
            }
            _unitOfWork.MedicamentoRecetados.Remove(medicamentoRecetado);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
    }