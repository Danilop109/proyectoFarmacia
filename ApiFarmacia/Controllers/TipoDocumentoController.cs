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
    public class TipoDocumentoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public TipoDocumentoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()
        {
            var llamado = await unitOfWork.TipoDocumentos.GetAllAsync();
            return Ok(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var llamado = await unitOfWork.TipoDocumentos.GetByIdAsync(id);
            return Ok(llamado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoDocumento>> Post(TipoDocumento tipoDocumento)
        {
            this.unitOfWork.TipoDocumentos.Add(tipoDocumento);
            await unitOfWork.SaveAsync();
            if (tipoDocumento == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = tipoDocumento.Id }, tipoDocumento);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoDocumento>> Put(int id, [FromBody] TipoDocumento tipoDocumento)
        {
            if (tipoDocumento == null)
                return NotFound();
            unitOfWork.TipoDocumentos.Update(tipoDocumento);
            await unitOfWork.SaveAsync();
            return tipoDocumento;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
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