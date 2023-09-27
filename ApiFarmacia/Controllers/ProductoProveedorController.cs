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
    public class ProductoProveedorController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductoProveedorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ProductoProveedor>>> Get()
        {
            var llamado = await unitOfWork.ProductoProveedores.GetAllAsync();
            return Ok(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var llamado = await unitOfWork.ProductoProveedores.GetByIdAsync(id);
            return Ok(llamado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProductoProveedor>> Post(ProductoProveedor productoProveedor)
        {
            this.unitOfWork.ProductoProveedores.Add(productoProveedor);
            await unitOfWork.SaveAsync();
            if (productoProveedor == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = productoProveedor.Id }, productoProveedor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProductoProveedor>> Put(int id,[FromBody] ProductoProveedor productoProveedor)
        {
            if(productoProveedor == null)
            return NotFound();
            unitOfWork.ProductoProveedores.Update(productoProveedor);
            await unitOfWork.SaveAsync();
            return productoProveedor;
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
            unitOfWork.Productos.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
}