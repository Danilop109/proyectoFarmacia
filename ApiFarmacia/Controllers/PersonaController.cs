using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers;
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public PersonaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            var personas = await unitOfWork.Personas.GetAllAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var persona = await unitOfWork.Personas.GetByIdAsync(id);
            return Ok(persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Persona>> Post(Persona persona)
        {
            this.unitOfWork.Personas.Add(persona);
            await unitOfWork.SaveAsync();
            if (persona == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = persona.Id }, persona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Persona>> Put(int id,[FromBody] Persona persona)
        {
            if(persona == null)
            return NotFound();
            unitOfWork.Personas.Update(persona);
            await unitOfWork.SaveAsync();
            return persona;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        { 
            var persona = await unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null){
                return NotFound();
            }
            unitOfWork.Personas.Remove(persona);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
