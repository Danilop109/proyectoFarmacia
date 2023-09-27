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

namespace ApiFarmacia.Controllers;

    public class CiudadController : BaseApiController
    {
       private readonly IUnitOfWork _unitofWork;
     

       public CiudadController(IUnitOfWork unitofWork)
        {
            this._unitofWork = unitofWork;
            
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Ciudad>>> Get()
        {
            var ciudades = await _unitofWork.Ciudades.GetAllAsync();
            return Ok(ciudades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get(int id)
        {
            var ciudad = await _unitofWork.Ciudades.GetByIdAsync(id);
            return Ok(ciudad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Ciudad>> Post(Ciudad ciudad)
        {
            this._unitofWork.Ciudades.Add(ciudad);
            await _unitofWork.SaveAsync();

            if(ciudad == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id= ciudad.Id}, ciudad);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<Ciudad>> Put(int id, [FromBody]Ciudad ciudad)
        {
            if(ciudad == null)
            
                return NotFound();
                _unitofWork.Ciudades.Update(ciudad);
                await _unitofWork.SaveAsync();
                return ciudad;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id){
            var ciudad = await _unitofWork.Ciudades.GetByIdAsync(id);
            if(ciudad == null)
            {
                return NotFound();
            }

            _unitofWork.Ciudades.Remove(ciudad);
            await _unitofWork.SaveAsync();
            return NoContent();
        }


    }
