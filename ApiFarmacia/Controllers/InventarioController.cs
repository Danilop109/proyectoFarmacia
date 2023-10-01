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

public class InventarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventarioDto>>> Get()
    {
        var inventario = await _unitOfWork.Inventarios.GetAllAsync();
        return _mapper.Map<List<InventarioDto>>(inventario);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InventarioDto>> Get(int id)
    {
        var inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
        if (inventario == null)
        {
            return NotFound();
        }
        return this._mapper.Map<InventarioDto>(inventario);
    }


    //Obetener todos los medicamentos con menos de (x) unidades en stock pene

    [HttpGet("MenosUnidades/{cantidad}")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<ActionResult<IEnumerable<InventarioDto>>> MenosUnidades(int cantidad)
    {
        var inventarios = await _unitOfWork.Inventarios.ObtenerMenosStockAsync(cantidad);
        if (inventarios == null)
        {
            return NotFound("No se encontraron productos menores a " + cantidad);
        }
        return _mapper.Map<List<InventarioDto>>(inventarios);
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Inventario>> Post(InventarioDto inventarioDto)
    {
        var inventario = this._mapper.Map<Inventario>(inventarioDto);
        this._unitOfWork.Inventarios.Add(inventario);
        await _unitOfWork.SaveAsync();
        if (inventario == null)
        {
            return BadRequest();
        }
        inventarioDto.Id = inventario.Id;
        return CreatedAtAction(nameof(Post), new { id = inventarioDto.Id }, inventarioDto);
    }
    public async Task<ActionResult<IEnumerable<InventarioDto>>> Get5()
    {
        var inventario = await _unitOfWork.Inventarios.GetAllAsync();
        return _mapper.Map<List<InventarioDto>>(inventario);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<InventarioDto>> Put(int id, [FromBody] InventarioDto inventarioDto)
    {
        if (inventarioDto == null)
        {
            return NotFound();
        }
        var inventario = this._mapper.Map<Inventario>(inventarioDto);
        _unitOfWork.Inventarios.Update(inventario);
        await _unitOfWork.SaveAsync();
        return inventarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
        if (inventario == null)
        {
            return NotFound();
        }
        _unitOfWork.Inventarios.Remove(inventario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}