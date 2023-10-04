using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiFarmacia.Dtos;
using Aplicacion.UnitOfWork;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers
{
    public class ProductoProveedorController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductoProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork =unitOfWork;
            this.mapper =mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ProductoProveedorDto>>> Get()
        {
            var llamado = await unitOfWork.ProductoProveedores.GetAllAsync();
            return mapper.Map<List<ProductoProveedorDto>>(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductoProveedorDto>> Get(int id)
        {
            var llamado = await unitOfWork.ProductoProveedores.GetByIdAsync(id);
            if (llamado == null){
                return NotFound();
            }
            return mapper.Map<ProductoProveedorDto>(llamado);
        }

        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProductoProveedor>> Post(ProductoProveedorDto productoProveedorDto)
        {
            var llamado = this.mapper.Map<ProductoProveedor>(productoProveedorDto);
            this.unitOfWork.ProductoProveedores.Add(llamado);
            await unitOfWork.SaveAsync();
            if (llamado == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = productoProveedorDto.Id }, productoProveedorDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProductoProveedorDto>> Put(int id,[FromBody] ProductoProveedorDto productoProveedorDto)
        {
            if(productoProveedorDto == null)
            return NotFound();
            var productoProvee = mapper.Map<ProductoProveedor>(productoProveedorDto);
            unitOfWork.ProductoProveedores.Update(productoProvee);
            await unitOfWork.SaveAsync();
            return productoProveedorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        { 
            var llamado = await unitOfWork.ProductoProveedores.GetByIdAsync(id);
            if (llamado == null){
                return NotFound();
            }
            unitOfWork.ProductoProveedores.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
}