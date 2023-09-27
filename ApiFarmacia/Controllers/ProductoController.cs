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
    public class ProductoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork =unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var llamado = await unitOfWork.Productos.GetAllAsync();
            return Ok(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var llamado = await unitOfWork.Productos.GetByIdAsync(id);
            return Ok(llamado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            this.unitOfWork.Productos.Add(producto);
            await unitOfWork.SaveAsync();
            if (producto == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Producto>> Put(int id,[FromBody] Producto producto)
        {
            if(producto == null)
            return NotFound();
            unitOfWork.Productos.Update(producto);
            await unitOfWork.SaveAsync();
            return producto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
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
