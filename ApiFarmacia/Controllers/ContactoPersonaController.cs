using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiFarmacia.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers;
 
    public class ContactoPersonaController : BaseApiController

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Get()
        {
            var contactopersonas = await _unitOfWork.ContactoPersonas.GetAllAsync();
            return _mapper.Map<List<ContactoPersonaDto>>(contactopersonas);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ContactoPersonaDto>> Get (int id)
        {
            var contactopersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
            if(contactopersona == null)
            {
                return NotFound();
            }
            return this._mapper.Map<ContactoPersonaDto>(contactopersona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ContactoPersona>> Post(ContactoPersonaDto contactoPersonaDto)
        {
            var contactoPersona = this._mapper.Map<ContactoPersona>(contactoPersonaDto);
            await _unitOfWork.SaveAsync();

        if(contactoPersona == null)
        {
            return BadRequest();
        }
        contactoPersonaDto.Id = contactoPersona.Id;
        return CreatedAtAction(nameof(Post), new {id = contactoPersonaDto.Id}, contactoPersonaDto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody] ContactoPersonaDto contactoPersonaDto)
        {
        if(contactoPersonaDto == null)
        {
            return NotFound();
        }
            var contactoPersona = this._mapper.Map<ContactoPersona>(contactoPersonaDto);
            _unitOfWork.ContactoPersonas.Update(contactoPersona);
            await _unitOfWork.SaveAsync();
            return contactoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var contactoPersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
            if(contactoPersona == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactoPersonas.Remove(contactoPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();

        }








    }
