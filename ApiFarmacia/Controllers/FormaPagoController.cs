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


namespace ApiFarmacia.Controllers;
    public class FormaPagoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FormaPagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<FormaPagoDto>>> Get()
        {
            var formaPagos = await _unitOfWork.FormaPagos.GetAllAsync();
            return _mapper.Map<List<FormaPagoDto>>(formaPagos);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<FormaPagoDto>> Get (int id)
        {
            
            var formaPago = await _unitOfWork.FormaPagos.GetByIdAsync(id);
            if(formaPago == null)
            {
                return NotFound();
            }
            return this._mapper.Map<FormaPagoDto>(formaPago);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<FormaPago>> Post(FormaPagoDto formaPagoDto)
        {
            var formaPago = this._mapper.Map<FormaPago>(formaPagoDto);
            this._unitOfWork.FormaPagos.Add(formaPago);
            await _unitOfWork.SaveAsync();

            if(formaPago == null)
            {
                return BadRequest();
            }
            formaPagoDto.Id = formaPago.Id;
            return CreatedAtAction(nameof(Post), new {id = formaPagoDto.Id}, formaPagoDto);
            }


            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult<FormaPagoDto>> Put(int id, [FromBody] FormaPagoDto formaPagoDto)
            {
            if(formaPagoDto == null)
            {
                return NotFound();
            }
                var formaPago = this._mapper.Map<FormaPago>(formaPagoDto);
                _unitOfWork.FormaPagos.Update(formaPago);
                await _unitOfWork.SaveAsync();
                return formaPagoDto;
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