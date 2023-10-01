using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiFarmacia.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers;
 
    public class MedicamentoRecetadoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicamentoRecetadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<MedicamentoRecetadoDto>>> Get()
        {
            var medicamentoRecetados = await _unitOfWork.MedicamentoRecetados.GetAllAsync();
            return _mapper.Map<List<MedicamentoRecetadoDto>>(medicamentoRecetados);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<MedicamentoRecetadoDto>> Get (int id)
        {
            var medicamentosRecetado = await _unitOfWork.MedicamentoRecetados.GetByIdAsync(id);
            if(medicamentosRecetado == null)
            {
                return NotFound();
            }
            return this._mapper.Map<MedicamentoRecetadoDto>(medicamentosRecetado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MedicamentoRecetado>> Post(MedicamentoRecetadoDto medicamentoRecetadoDto)
        {
            var medicamentoRecetado = _mapper.Map<MedicamentoRecetado>(medicamentoRecetadoDto);
            this._unitOfWork.MedicamentoRecetados.Add(medicamentoRecetado);
            await _unitOfWork.SaveAsync();

            if(medicamentoRecetado == null)
            {
                return BadRequest();
            }
            medicamentoRecetadoDto.Id = medicamentoRecetado.Id;
            return CreatedAtAction(nameof(Post), new {id = medicamentoRecetadoDto.Id}, medicamentoRecetadoDto);
            }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MedicamentoRecetadoDto>> Put(int id, [FromBody] MedicamentoRecetadoDto medicamentoRecetadoDto)
        {
        if(medicamentoRecetadoDto == null)
        {
            return NotFound();
        }
            var medicamentoRecetado = this._mapper.Map<MedicamentoRecetado>(medicamentoRecetadoDto);
            _unitOfWork.MedicamentoRecetados.Update(medicamentoRecetado);
            await _unitOfWork.SaveAsync();
            return medicamentoRecetadoDto;
        }

        [HttpDelete("{id}")]
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