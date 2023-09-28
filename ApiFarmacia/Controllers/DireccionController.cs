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
    public class DireccionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DireccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<DireccionDto>>> Get()
        {
            var direcciones = await _unitOfWork.Direcciones.GetAllAsync();
            return _mapper.Map<List<DireccionDto>>(direcciones);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DireccionDto>> Get (int id)
        {
            var direccion = await _unitOfWork.Direcciones.GetByIdAsync(id);
            if(direccion == null)
            {
                return NotFound();
            }
            return this._mapper.Map<DireccionDto>(direccion);
        }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult<Direccion>> Post(DireccionDto direccionDto)
            {
            var direccion = this._mapper.Map<Direccion>(direccionDto);
            this._unitOfWork.Direcciones.Add(direccion);
            await _unitOfWork.SaveAsync();
            if(direccion == null)
            {
                return BadRequest();
            }
            direccionDto.Id = direccion.Id;
            return CreatedAtAction(nameof(Post), new {id = direccionDto.Id}, direccionDto);
            }


            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult<DireccionDto>> Put(int id, [FromBody] DireccionDto direccionDto)
            {
            if(direccionDto == null)
            {
                return NotFound();
            }
                var direccion = this._mapper.Map<Direccion>(direccionDto);
                _unitOfWork.Direcciones.Update(direccion);
                await _unitOfWork.SaveAsync();
                return direccionDto;
            }

            [HttpDelete("{id}")]
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