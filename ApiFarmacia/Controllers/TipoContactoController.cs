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
    public class TipoContactoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoContactoDto>>> Get()
        {
            var llamado = await unitOfWork.TipoContactos.GetAllAsync();
            return mapper.Map<List<TipoContactoDto>>(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoContactoDto>> Get(int id)
        {
            var llamado = await unitOfWork.TipoContactos.GetByIdAsync(id);
            if (llamado == null)
            {
                return NotFound();
            }
            return mapper.Map<TipoContactoDto>(llamado);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoContacto>> Post(TipoContactoDto tipoContactoDto)
        {
            var llamado = this.mapper.Map<TipoContacto>(tipoContactoDto);
            this.unitOfWork.TipoContactos.Add(llamado);
            await unitOfWork.SaveAsync();
            if (llamado == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = tipoContactoDto.Id }, tipoContactoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoContactoDto>> Put(int id, [FromBody] TipoContactoDto tipoContactoDto)
        {
            if (tipoContactoDto == null)
                return NotFound();
            var llamado = mapper.Map<TipoContacto>(tipoContactoDto);
            unitOfWork.TipoContactos.Update(llamado);
            await unitOfWork.SaveAsync();
            return tipoContactoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            var llamado = await unitOfWork.TipoContactos.GetByIdAsync(id);
            if (llamado == null)
            {
                return NotFound();
            }
            unitOfWork.TipoContactos.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

