using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiFarmacia.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers;
   
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper= mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var pais = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PaisDto>>(pais);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PaisDto>> Get (int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if(pais == null)
            {
                return NotFound();
            }
            return this._mapper.Map<PaisDto>(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
        {
            var pais = _mapper.Map<Pais>(paisDto);
            this._unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();
        if(pais == null)
        {
            return BadRequest();
        }
        paisDto.Id= pais.Id;
        return CreatedAtAction(nameof(Post), new {id = paisDto.Id}, paisDto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PaisDto>> Put(int id, [FromBody]PaisDto paisDto)
        {
        if(paisDto == null)
        {
            return NotFound();
        }
            var pais = this._mapper.Map<Pais>(paisDto);
            _unitOfWork.Paises.Update(pais);
            await _unitOfWork.SaveAsync();
            return paisDto;
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