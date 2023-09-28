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
    public class TipoDocumentoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TipoDocumentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoDocumentoDto>>> Get()
        {
            var llamado = await unitOfWork.TipoDocumentos.GetAllAsync();
            return  mapper.Map<List<TipoDocumentoDto>>(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoDocumentoDto>> Get(int id)
        {
            var llamado = await unitOfWork.TipoDocumentos.GetByIdAsync(id);
            if (llamado == null){
                return NotFound();
            }
            return mapper.Map<TipoDocumentoDto>(llamado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoDocumento>> Post(TipoDocumentoDto tipoDocumentoDto)
        {
            var llamado = this.mapper.Map<TipoDocumento>(tipoDocumentoDto);
            this.unitOfWork.TipoDocumentos.Add(llamado);
            await unitOfWork.SaveAsync();
            if (llamado == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = tipoDocumentoDto.Id }, tipoDocumentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoDocumentoDto>> Put(int id, [FromBody] TipoDocumentoDto tipoDocumentoDto)
        {
            if (tipoDocumentoDto == null)
                return NotFound();
            var llamado = mapper.Map<TipoDocumento>(tipoDocumentoDto);
            unitOfWork.TipoDocumentos.Update(llamado);
            await unitOfWork.SaveAsync();
            return tipoDocumentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            var llamado = await unitOfWork.TipoDocumentos.GetByIdAsync(id);
            if (llamado == null)
            {
                return NotFound();
            }
            unitOfWork.TipoDocumentos.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}