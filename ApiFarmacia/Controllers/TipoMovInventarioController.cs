using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers
{
    public class TipoMovInventarioController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public TipoMovInventarioController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoMovInventario>>> Get()
        {
            var llamado = await unitOfWork.TipoMovInventarios.GetAllAsync();
            return Ok(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var llamado = await unitOfWork.TipoMovInventarios.GetByIdAsync(id);
            return Ok(llamado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoMovInventario>> Post(TipoMovInventario tipoMovInventario)
        {
            this.unitOfWork.TipoMovInventarios.Add(tipoMovInventario);
            await unitOfWork.SaveAsync();
            if (tipoMovInventario == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = tipoMovInventario.Id }, tipoMovInventario);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoMovInventario>> Put(int id, [FromBody] TipoMovInventario tipoMovInventario)
        {
            if (tipoMovInventario == null)
                return NotFound();
            unitOfWork.TipoMovInventarios.Update(tipoMovInventario);
            await unitOfWork.SaveAsync();
            return tipoMovInventario;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
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