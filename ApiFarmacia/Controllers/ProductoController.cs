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
    public class ProductoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork =unitOfWork;
            this.mapper =mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get()
        {
            var llamado = await unitOfWork.Productos.GetAllAsync();
            return  mapper.Map<List<ProductoDto>>(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductoDto>> Get(int id)
        {
            var llamado = await unitOfWork.Productos.GetByIdAsync(id);
            if (llamado == null){
                return NotFound();
            }
            return mapper.Map<ProductoDto>(llamado);
        }
        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Producto>> Post(ProductoDto productoDto)
        {
            var llamado = this.mapper.Map<Producto>(productoDto);
            this.unitOfWork.Productos.Add(llamado);
            await unitOfWork.SaveAsync();
            if (llamado == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = productoDto.Id }, productoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProductoDto>> Put(int id,[FromBody] ProductoDto productoDto)
        {
            if(productoDto == null)
            return NotFound();
            var producto = mapper.Map<Producto>(productoDto);
            unitOfWork.Productos.Update(producto);
            await unitOfWork.SaveAsync();
            return productoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        { 
            var llamado = await unitOfWork.Productos.GetByIdAsync(id);
            if (llamado == null){
                return NotFound();
            }
            unitOfWork.Productos.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
