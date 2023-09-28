using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers
{
    public class TipoMovInventarioController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TipoMovInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoMovInventarioDto>>> Get()
        {
            var tipoMovInventario = await unitOfWork.TipoMovInventarios.GetAllAsync();
            return this.mapper.Map<List<TipoMovInventarioDto>>(tipoMovInventario);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoMovInventarioDto>> Get(int id)
        {
            var tipoMovInventario = await unitOfWork.TipoMovInventarios.GetByIdAsync(id);
            if(tipoMovInventario == null)
            {
                return NotFound();
            }
            return this.mapper.Map<TipoMovInventarioDto>(tipoMovInventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoMovInventario>> Post(TipoMovInventarioDto tipoMovInventarioDto)
        {
            var tipoMovInventario = this.mapper.Map<TipoMovInventario>(tipoMovInventarioDto);
            this.unitOfWork.TipoMovInventarios.Add(tipoMovInventario);
            await unitOfWork.SaveAsync();
            if (tipoMovInventario == null)
            {
                return BadRequest();
            }
            tipoMovInventarioDto.Id = tipoMovInventario.Id;
            return CreatedAtAction(nameof(Post), new { id = tipoMovInventarioDto.Id }, tipoMovInventarioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoMovInventarioDto>> Put(int id, [FromBody] TipoMovInventarioDto tipoMovInventarioDto)
        {
            if (tipoMovInventarioDto == null)
            {
                return NotFound();
            }
            var tipoMovInventario = this.mapper.Map<TipoMovInventario>(tipoMovInventarioDto);
            unitOfWork.TipoMovInventarios.Update(tipoMovInventario);
            await unitOfWork.SaveAsync();
            return tipoMovInventario;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            var llamado = await unitOfWork.TipoMovInventarios.GetByIdAsync(id);
            if (llamado == null)
            {
                return NotFound();
            }
            unitOfWork.TipoMovInventarios.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}