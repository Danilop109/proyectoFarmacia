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
  
    public class DepartamentoController : BaseApiController
    {
         private readonly IUnitOfWork _unitOfWork;

        public DepartamentoController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Departamento>>> Get()
        {
            var departamentos = await _unitOfWork.Departamentos.GetAllAsync();
            return Ok(departamentos);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            return Ok(departamento);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Departamento>> Post(Departamento departamento)
        {
            this._unitOfWork.Departamentos.Add(departamento);
            await _unitOfWork.SaveAsync();

        if(departamento == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = departamento.Id}, departamento);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Departamento>> Put(int id, [FromBody] Departamento departamento)
        {
        if(departamento == null)
            return NotFound();
            _unitOfWork.Departamentos.Update(departamento);
            await _unitOfWork.SaveAsync();
            return departamento;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            if(departamento == null)
            {
                return NotFound();
            }
            _unitOfWork.Departamentos.Remove(departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
    }
}