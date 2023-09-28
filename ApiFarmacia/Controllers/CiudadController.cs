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

    public class CiudadController : BaseApiController
    {
       private readonly IUnitOfWork _unitofWork;
       private readonly IMapper _mapper;
     

       public CiudadController(IUnitOfWork unitofWork , IMapper mapper)
        {
            this._unitofWork = unitofWork;
            this._mapper = mapper;
            
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
        {
            var ciudades = await _unitofWork.Ciudades.GetAllAsync();
            return _mapper.Map<List<CiudadDto>>(ciudades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var ciudad = await _unitofWork.Ciudades.GetByIdAsync(id);
            if(ciudad == null){
                return NotFound();
            }
            return this._mapper.Map<CiudadDto>(ciudad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Ciudad>> Post(CiudadDto ciudadDto)
        {
            var ciudad = this._mapper.Map<Ciudad>(ciudadDto);
            this._unitofWork.Ciudades.Add(ciudad);
            await _unitofWork.SaveAsync();

            if(ciudad == null)
            {
                return BadRequest();
            }
            ciudadDto.Id = ciudad.Id;
            return CreatedAtAction(nameof(Post), new {id= ciudadDto.Id}, ciudadDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody]CiudadDto ciudadDto)
        {
            if(ciudadDto == null)
            {
                return NotFound();
            }
            
            var ciudad = this._mapper.Map<Ciudad>(ciudadDto);
            _unitofWork.Ciudades.Update(ciudad);
            await _unitofWork.SaveAsync();
            return ciudadDto;
            
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
