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

namespace ApiFarmacia.Controllers
{
    public class PresentacionController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PresentacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PresentacionDto>>> Get()
        {
            var presentaciones = await unitOfWork.Presentaciones.GetAllAsync();
            return mapper.Map<List<PresentacionDto>> (presentaciones);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PresentacionDto>> Get(int id)
        {
            var presentacion = await unitOfWork.Presentaciones.GetByIdAsync(id);
            if(presentacion == null){
                return NotFound();
            }
            return mapper.Map<PresentacionDto>(presentacion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Presentacion>> Post(PresentacionDto presentacionDto)
        {
            var presentacion= mapper.Map<Presentacion>(presentacionDto);
            this.unitOfWork.Presentaciones.Add(presentacion);
            await unitOfWork.SaveAsync();
            if (presentacion == null)
            {
                return BadRequest();
            }
            presentacionDto.Id = presentacion.Id;
            return CreatedAtAction(nameof(Post), new { id = presentacionDto.Id }, presentacionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PresentacionDto>> Put(int id,[FromBody] PresentacionDto presentacionDto)
        {
            if(presentacionDto == null){
                return NotFound();
            }
            var presentacion = mapper.Map<Presentacion>(presentacionDto);
            unitOfWork.Presentaciones.Update(presentacion);
            await unitOfWork.SaveAsync();
            return presentacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        { 
            var presentacion = await unitOfWork.Presentaciones.GetByIdAsync(id);
            if (presentacion == null){
                return NotFound();
            }
            unitOfWork.Presentaciones.Remove(presentacion);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}