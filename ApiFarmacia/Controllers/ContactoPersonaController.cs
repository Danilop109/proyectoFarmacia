using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers;
 
    public class ContactoPersonaController : BaseApiController

    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactoPersonaController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ContactoPersona>>> Get()
        {
            var contactopersonas = await _unitOfWork.ContactoPersonas.GetAllAsync();
            return Ok(contactopersonas);
        }

                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var contactopersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
            return Ok(contactopersona);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ContactoPersona>> Post(ContactoPersona contactoPersona)
        {
            this._unitOfWork.ContactoPersonas.Add(contactoPersona);
            await _unitOfWork.SaveAsync();

        if(contactoPersona == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = contactoPersona.Id}, contactoPersona);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ContactoPersona>> Put(int id, [FromBody] ContactoPersona contactoPersona)
        {
        if(contactoPersona == null)
            return NotFound();
            _unitOfWork.ContactoPersonas.Update(contactoPersona);
            await _unitOfWork.SaveAsync();
            return contactoPersona;
        }

        [HttpPut("{id}")]
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
