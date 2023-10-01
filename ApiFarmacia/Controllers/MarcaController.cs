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
    public class MarcaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MarcaController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<MarcaDto>>> Get()
        {
            var marcas = await _unitOfWork.Marcas.GetAllAsync();
            return _mapper.Map<List<MarcaDto>>(marcas);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MarcaDto>> Get (int id)
        {
            var marca = await _unitOfWork.Marcas.GetByIdAsync(id);
            if(marca == null)
            {
                return NotFound();
            }
         
            return _mapper.Map<MarcaDto>(marca);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Marca>> Post(MarcaDto marcaDto)
        {
            var marca = this._mapper.Map<Marca>(marcaDto);
            this._unitOfWork.Marcas.Add(marca);
            await _unitOfWork.SaveAsync();
            if(marca == null)
            {
                return BadRequest();
            }
            marcaDto.Id = marca.Id;
            return CreatedAtAction(nameof(Post), new {id = marcaDto.Id}, marcaDto);
            }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MarcaDto>> Put(int id, [FromBody] MarcaDto marcaDto)
        {
        if(marcaDto == null)
        {
            return NotFound();
        }
            var marca = this._mapper.Map<Marca>(marcaDto);
            _unitOfWork.Marcas.Update(marca);
            await _unitOfWork.SaveAsync();
            return marcaDto;
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