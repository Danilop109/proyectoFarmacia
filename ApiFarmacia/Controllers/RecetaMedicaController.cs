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
    [Route("[controller]")]
    public class RecetaMedicaController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public RecetaMedicaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<RecetaMedica>>> Get()
        {
            var llamado = await unitOfWork.RecetaMedicas.GetAllAsync();
            return Ok(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var llamado = await unitOfWork.RecetaMedicas.GetByIdAsync(id);
            return Ok(llamado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RecetaMedica>> Post(RecetaMedica recetaMedica)
        {
            this.unitOfWork.RecetaMedicas.Add(recetaMedica);
            await unitOfWork.SaveAsync();
            if (recetaMedica == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = recetaMedica.Id }, recetaMedica);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RecetaMedica>> Put(int id, [FromBody] RecetaMedica recetaMedica)
        {
            if (recetaMedica == null)
                return NotFound();
            unitOfWork.RecetaMedicas.Update(recetaMedica);
            await unitOfWork.SaveAsync();
            return recetaMedica;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
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