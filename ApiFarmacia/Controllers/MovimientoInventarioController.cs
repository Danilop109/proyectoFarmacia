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

    [HttpGet("GetSellMedicament")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<int> GetSell()
    {
        var medicamento = await _unitOfWork.MovimientoInventarios.GetSellParacetamol();
        return _mapper.Map<int>(medicamento);
    }

    [HttpGet("totalSales")]

    public async Task<double> GetSales()
    {
        var producto = await _unitOfWork.MovimientoInventarios.MediTotalSales();

        return _mapper.Map<double>(producto);
    }
    //CONSULTA 9: Medicamentos que no han sido vendidos.
    [HttpGet("GetNotSoldYet")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventarioDto>>> GetNot()
    {
        var productosNoVendidos = await _unitOfWork.MovimientoInventarios.GetNotSoldYet();
        if (productosNoVendidos == null || !productosNoVendidos.Any())
        {
            return NotFound("No se encontraron medicamentos que no fueran vendidos.");
        }
        return _mapper.Map<List<InventarioDto>>(productosNoVendidos);
    }

    [HttpGet("GetPatientParacetamol")]
    public async Task<IEnumerable<PersonaDto>> GetPatient()
    {
        var patientParacetamol = await _unitOfWork.MovimientoInventarios.GetPatientParacetamol();
        return _mapper.Map<IEnumerable<PersonaDto>>(patientParacetamol);
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

    //CONSULTA 18: Cantidad de ventas realizadas por cada empleado en 2023.
    [HttpGet("GetCantidadVendidasPorEmpleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> GetCountSales()
    {
        var count = await _unitOfWork.MovimientoInventarios.GetCountSales();
        return _mapper.Map<IEnumerable<object>>(count);
    }

    //CONSULTA 20: Empleados que hayan hecho más de 5 ventas en total.
    [HttpGet("GetCantidadEmpleadoMas5Ventas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> GetCountMoreThan5Sales()
    {
        var count5 = await _unitOfWork.MovimientoInventarios.GetCountMoreThan5Sales();
        return _mapper.Map<IEnumerable<object>>(count5);
    }

    //CONSULTA 24: Proveedor que ha suministrado más medicamentos en 2023.
    [HttpGet("GetCantidadProveedoresSuministraron")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> GetProveeMoreMedi()
    {
        var suministra = await _unitOfWork.MovimientoInventarios.GetProveeMoreMedi2023();
        return _mapper.Map<IEnumerable<object>>(suministra);
    }

    //CONSULTA 26: Total de medicamentos vendidos por mes en 2023.
    [HttpGet("GetTotalByMonth2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> GetTotalMediSoldByMonth()
    {
        var sold = await _unitOfWork.MovimientoInventarios.GetTotalMediSoldByMonth();
        return _mapper.Map<IEnumerable<object>>(sold);
    }
    //CONSULTA 28: Número total de proveedores que suministraron medicamentos en 2023.
    [HttpGet("Totalprovee2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> Totalprovee2023()
    {
        var total = await _unitOfWork.MovimientoInventarios.TotalproveeGive2023();
        return _mapper.Map<IEnumerable<object>>(total);
    }

    //CONSULTA 32: Empleado que ha vendido la mayor cantidad de medicamentos distintos en 2023.
    [HttpGet("GetEmployeeMediSold2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> GetEmployeeMediSoldyear()
    {
        var total = await _unitOfWork.MovimientoInventarios.GetEmployeeMediSold2023();
        return _mapper.Map<object>(total);
    }

    //CONSULTA 34: Medicamentos que no han sido vendidos en 2023.
    [HttpGet("GetMediNotSold2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<object>> GetMediNotSold()
    {
        var total = await _unitOfWork.MovimientoInventarios.GetMediNotSold2023();
        return _mapper.Map<IEnumerable<object>>(total);
    }
    //CONSULTA 36: Total de medicamentos vendidos en el primer trimestre de 2023.
    [HttpGet("GetFirstQuarterOf2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<object>> GetFirstQuarter2023()
    {
        var total = await _unitOfWork.MovimientoInventarios.GetFirstQuarterOf2023();
        return _mapper.Map<IEnumerable<object>>(total);
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