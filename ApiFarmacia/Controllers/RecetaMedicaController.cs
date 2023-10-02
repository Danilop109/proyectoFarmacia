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
    public class RecetaMedicaController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RecetaMedicaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork =unitOfWork;
            this.mapper =mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<RecetaMedicaDto>>> Get()
        {
            var llamado = await unitOfWork.RecetaMedicas.GetAllAsync();
            return  mapper.Map<List<RecetaMedicaDto>>(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RecetaMedicaDto>> Get(int id)
        {
            var llamado = await unitOfWork.RecetaMedicas.GetByIdAsync(id);
            if (llamado == null){
                return NotFound();
            }
            return mapper.Map<RecetaMedicaDto>(llamado);
        }

        [HttpGet("RecetaSinceDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<RecetaMedicaDto>>> Get3()
        {
            var receta= await unitOfWork.RecetaMedicas.GetRecetaSinceDate();
            return mapper.Map<List<RecetaMedicaDto>>(receta);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RecetaMedica>> Post(RecetaMedicaDto recetaMedicaDto)
        {
            var llamado = this.mapper.Map<RecetaMedica>(recetaMedicaDto);
            this.unitOfWork.RecetaMedicas.Add(llamado);
            await unitOfWork.SaveAsync();
            if (llamado == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = recetaMedicaDto.Id }, recetaMedicaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RecetaMedicaDto>> Put(int id, [FromBody] RecetaMedicaDto recetaMedicaDto)
        {
            if (recetaMedicaDto == null)
                return NotFound();
            var llamado = mapper.Map<RecetaMedica>(recetaMedicaDto);
            unitOfWork.RecetaMedicas.Update(llamado);
            await unitOfWork.SaveAsync();
            return recetaMedicaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            var llamado = await unitOfWork.RecetaMedicas.GetByIdAsync(id);
            if (llamado == null)
            {
                return NotFound();
            }
            unitOfWork.RecetaMedicas.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}