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
  
    public class DetalleMovInventarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleMovInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

    public DetalleMovInventarioController()
    {
    }

    [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<DetalleMovInventarioDto>>> Get()
        {
            var detalleMovInventario = await _unitOfWork.DetalleMovInventarios.GetAllAsync();
            return _mapper.Map<List<DetalleMovInventarioDto>>(detalleMovInventario);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DetalleMovInventarioDto>> Get (int id)
        {
            var detalleMovInventario = await _unitOfWork.DetalleMovInventarios.GetByIdAsync(id);
            if(detalleMovInventario == null)
            {
                return NotFound();
            }
            return this._mapper.Map<DetalleMovInventarioDto>(detalleMovInventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DetalleMovInventario>> Post(DetalleMovInventarioDto detalleMovInventarioDto)
        {
            var detalleMovInventario = this._mapper.Map<DetalleMovInventario>(detalleMovInventarioDto);
            this._unitOfWork.DetalleMovInventarios.Add(detalleMovInventario);
            await _unitOfWork.SaveAsync();
            if(detalleMovInventario == null)
            {
                return BadRequest();
            }
            detalleMovInventarioDto.Id = detalleMovInventario.Id;
            return CreatedAtAction(nameof(Post), new {id = detalleMovInventarioDto.Id}, detalleMovInventarioDto);
            }


            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult<DetalleMovInventarioDto>> Put(int id, [FromBody] DetalleMovInventarioDto detalleMovInventarioDto)
            {
            if(detalleMovInventarioDto == null)
            {
                return NotFound();
            }
                var detalleMovInventario = this._mapper.Map<DetalleMovInventario>(detalleMovInventarioDto);
                _unitOfWork.DetalleMovInventarios.Update(detalleMovInventario);
                await _unitOfWork.SaveAsync();
                return detalleMovInventarioDto;
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