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

namespace ApiFarmacia.Controllers;

public class MovimientoInventarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovimientoInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MovimientoInventarioDto>>> Get()
    {
        var movimientoInventario = await _unitOfWork.MovimientoInventarios.GetAllAsync();
        return _mapper.Map<List<MovimientoInventarioDto>>(movimientoInventario);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MovimientoInventario>> Get(int id)
    {
        var movimientoInventario = await _unitOfWork.MovimientoInventarios.GetByIdAsync(id);
        if (movimientoInventario == null)
        {
            return NotFound();
        }
        return this._mapper.Map<MovimientoInventario>(movimientoInventario);
    }

    [HttpGet("totalSales")]

    public async Task<double> GetSales()
    {
        var producto = await _unitOfWork.MovimientoInventarios.MediTotalSales();

        return _mapper.Map<double>(producto);
    }

    [HttpGet("GetPatientParacetamol")]


    public async Task<IEnumerable<PersonaDto>> GetPatient()
    {
        var patientParacetamol = await _unitOfWork.MovimientoInventarios.GetPatientParacetamol();
        return _mapper.Map<IEnumerable<PersonaDto>> (patientParacetamol);
    }

    // CONSULTA 14: Obtener el total de medicamentos vendidos en marzo de 2023
    [HttpGet("GetMediSale2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> getmediSale()
    {
        var mediSale2023 = await _unitOfWork.MovimientoInventarios.GetMediSale2023();
        return _mapper.Map<IEnumerable<object>>(mediSale2023);
    }

    // CONSULTAS 16: Ganancia total por proveedor en 2023 (asumiendo un campo precioCompra en Compras).
    [HttpGet("GetGainProveedores2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> GetGainProvee2023()
    {
        var gain = await _unitOfWork.MovimientoInventarios.GainProvee2023();
        return _mapper.Map<IEnumerable<object>>(gain);
    }
    



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoInventario>> Post(MovimientoInventarioDto movimientoInventarioDto)
    {
        var movimientoInventario = this._mapper.Map<MovimientoInventario>(movimientoInventarioDto);
        this._unitOfWork.MovimientoInventarios.Add(movimientoInventario);
        await _unitOfWork.SaveAsync();
        if (movimientoInventario == null)
        {
            return BadRequest();
        }
        movimientoInventarioDto.Id = movimientoInventario.Id;
        return CreatedAtAction(nameof(Post), new { id = movimientoInventarioDto.Id }, movimientoInventarioDto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoInventarioDto>> Put(int id, [FromBody] MovimientoInventarioDto movimientoInventarioDto)
    {
        if (movimientoInventarioDto == null)
        {
            return NotFound();
        }
        var movimientoInventario = this._mapper.Map<MovimientoInventario>(movimientoInventarioDto);
        _unitOfWork.MovimientoInventarios.Update(movimientoInventario);
        await _unitOfWork.SaveAsync();
        return movimientoInventarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var movimientoInventario = await _unitOfWork.MovimientoInventarios.GetByIdAsync(id);
        if (movimientoInventario == null)
        {
            return NotFound();
        }
        _unitOfWork.MovimientoInventarios.Remove(movimientoInventario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}