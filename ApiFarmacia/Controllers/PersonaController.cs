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

namespace ApiFarmacia.Controllers;
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper =mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var personas = await unitOfWork.Personas.GetAllAsync();
            return mapper.Map<List<PersonaDto>>(personas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var persona = await unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null){
                return NotFound();
            }
            return mapper.Map<PersonaDto>(persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Persona>> Post(PersonaDto personaDto)
        {
            var persona = this.mapper.Map<Persona>(personaDto);
            this.unitOfWork.Personas.Add(persona);
            await unitOfWork.SaveAsync();
            if (persona == null)
            {
                return BadRequest();
            }
            personaDto.Id = persona.Id;
            return CreatedAtAction(nameof(Post), new { id = personaDto.Id }, personaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonaDto>> Put(int id,[FromBody] PersonaDto personaDto)
        {
            if(personaDto == null){
                return NotFound();
            }
            var persona= mapper.Map<Persona>(personaDto);
            unitOfWork.Personas.Update(persona);
            await unitOfWork.SaveAsync();
            return personaDto;
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
