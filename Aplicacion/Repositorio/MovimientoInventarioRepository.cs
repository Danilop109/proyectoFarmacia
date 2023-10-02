using System.Globalization;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventario
    {
        private readonly ApiFarmaciaContext _context;
        public MovimientoInventarioRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<MovimientoInventario>> GetAllAsync()
        {
            return await _context.MovimientoInventarios
            .ToListAsync();
        }

        public override async Task<MovimientoInventario> GetByIdAsync(int id)
        {
            return await _context.MovimientoInventarios

            .FirstOrDefaultAsync(p => p.Id == id);
        }

        //CONCULTA 8: Cantidad total de dinero recaudado por las ventas de medicamentos.
        public async Task<double> MediTotalSales()
        {

            var totalDineroVentas = await (
                from dm in _context.DetalleMovInventarios
                join d in _context.MovimientoInventarios on dm.IdMovimientoInvFk equals d.Id
                where d.IdTipoMovimientoInventarioFk == 2
                select dm.Cantidad * dm.Precio
            ).SumAsync();

            return totalDineroVentas;
        }
        //CONSULTA 9: Medicamentos que no han sido vendidos.
        public async Task<IEnumerable<Inventario>> GetNotSoldYet()
        {
            var soldMedicines = await (
                from mv in _context.MovimientoInventarios
                where mv.IdTipoMovimientoInventarioFk == 2
                select mv.IdInventarioFk
            ).ToListAsync();

            var notSoldMedicines = await (
                from i in _context.Inventarios
                where !soldMedicines.Contains(i.Id)
                select i
            ).ToListAsync();

            return notSoldMedicines;
        }
        //CONSULTA 12:Pacientes que han comprado Paracetamol.
        public async Task<IEnumerable<Persona>> GetPatientParacetamol()
        {
            return await (
                from rm in _context.MovimientoInventarios
                join r in _context.RecetaMedicas on rm.IdRecetaMedicaFk equals r.Id
                join p in _context.Personas on r.IdPacienteFk equals p.Id
                join i in _context.Inventarios on r.InventarioId equals i.Id
                where rm.IdTipoMovimientoInventarioFk == 1
                where i.Id == 3
                where i.Nombre.ToLower() == "paracetamol"
                select p

                ).ToListAsync();
        }

        // CONSULTA 14: Obtener el total de medicamentos vendidos en marzo de 2023

        public async Task<IEnumerable<object>> GetMediSale2023()
        {
            var inicioMarzo2023 = new DateTime(2023, 3, 1);
            var finMarzo2023 = new DateTime(2023, 3, 31);
            return await (
                from dm in _context.MovimientoInventarios
                join inv in _context.Inventarios on dm.IdInventarioFk equals inv.Id
                where dm.IdTipoMovimientoInventarioFk == 2
                where dm.FechaMovimiento >= inicioMarzo2023 && dm.FechaMovimiento <= finMarzo2023
                select new
                {
                    IdInventario = inv.Id,
                    NombreInventario = inv.Nombre
                }
            ).ToListAsync();
        }

        // CONSULTAS 16: Ganancia total por proveedor en 2023 (asumiendo un campo precioCompra en Compras).
        public async Task<IEnumerable<object>> GainProvee2023()
        {
            var inicioYear = new DateTime(2023, 1, 1);
            var finalYear = new DateTime(2023, 12, 31);
            return await (
                from mv in _context.MovimientoInventarios
                join p in _context.Personas on mv.IdClienteFk equals p.Id
                join dm in _context.DetalleMovInventarios on mv.IdInventarioFk equals dm.Id
                where mv.IdTipoMovimientoInventarioFk == 1
                where mv.FechaMovimiento >= inicioYear && mv.FechaMovimiento <= finalYear
                where p.IdRolFk == 3

                group new { p, dm } by new { p.Id, p.Nombre } into grouped
                select new
                {
                    IdProveedor = grouped.Key.Id,
                    NombreProveedor = grouped.Key.Nombre,
                    PrecioCompraTotal = grouped.Sum(item => item.dm.Precio * item.dm.Cantidad)
                }
            ).ToListAsync();
        }

        //CONSULTA 18: Cantidad de ventas realizadas por cada empleado en 2023.
        public async Task<IEnumerable<object>> GetCountSales()
        {
            return await (
                from mv in _context.MovimientoInventarios
                join p in _context.Personas on mv.IdVendedorFk equals p.Id
                where mv.IdTipoMovimientoInventarioFk == 2
                group mv by new { p.Id, p.Nombre } into grouped
                select new
                {
                    IdVendedor = grouped.Key.Id,
                    NombreVendedor = grouped.Key.Nombre,
                    NumeroVentas = grouped.Count()
                }
                ).ToListAsync();
        }

        //CONSULTA 20: Empleados que hayan hecho más de 5 ventas en total.
        public async Task<IEnumerable<object>> GetCountMoreThan5Sales()
        {
            return await (
                from mv in _context.MovimientoInventarios
                join p in _context.Personas on mv.IdVendedorFk equals p.Id
                where mv.IdTipoMovimientoInventarioFk == 2
                group mv by new { p.Id, p.Nombre } into grouped
                where grouped.Count() > 5
                select new
                {
                    IdVendedor = grouped.Key.Id,
                    NombreVendedor = grouped.Key.Nombre,
                    NumeroVentas = grouped.Count()
                }
                ).ToListAsync();
        }

        //CONSULTA 24: Proveedor que ha suministrado más medicamentos en 2023.
        public async Task<IEnumerable<object>> GetProveeMoreMedi2023()
        {
            var inicioYear = new DateTime(2023, 1, 1);
            var finalYear = new DateTime(2023, 12, 31);
            return await (
               from mv in _context.MovimientoInventarios
               join p in _context.Personas on mv.IdClienteFk equals p.Id
               join dm in _context.DetalleMovInventarios on mv.IdInventarioFk equals dm.Id
               where mv.IdTipoMovimientoInventarioFk == 1
               where p.IdRolFk == 3
               where mv.FechaMovimiento >= inicioYear && mv.FechaMovimiento <= finalYear
               group new { mv, dm } by new { p.Id, p.Nombre } into grouped
               select new
               {
                   IdProveedor = grouped.Key.Id,
                   NombreProvedor = grouped.Key.Nombre,
                   VecesSuministradas = grouped.Count()
               }
                ).ToListAsync();

        }

        //CONSULTA 26: Total de medicamentos vendidos por mes en 2023. Probablemente no por mes
        public async Task<IEnumerable<object>> GetTotalMediSoldByMonth()
        {
            var resultadoPorMes = await (
                from di in _context.DetalleMovInventarios
                join i in _context.Inventarios on di.IdInventarioFk equals i.Id
                join mv in _context.MovimientoInventarios on di.IdMovimientoInvFk equals mv.Id
                where mv.IdTipoMovimientoInventarioFk == 2
                where mv.FechaMovimiento.Year == 2023
                group new { mv, i, di } by new { mv.FechaMovimiento.Year, mv.FechaMovimiento.Month } into grouped
                orderby grouped.Key.Month
                select new
                {
                    Year = grouped.Key.Year,
                    Month = grouped.Key.Month,
                    TotalMedicinesSold = grouped.Sum(item => item.di.Cantidad),
                    Medicamentos = grouped.Select(item => new
                    {
                        MedicamentoId = item.i.Id,
                        NombreMedicamento = item.i.Nombre,
                        CantidadVendida = item.di.Cantidad
                    }).ToList()
                }
            ).ToListAsync();

            return resultadoPorMes;
        }

        //CONSULTA 28: Número total de proveedores que suministraron medicamentos en 2023.NO ME SALEEE, TE ODIO
        public async Task<IEnumerable<object>> TotalproveeGive2023()
        {
            var inicioYear = new DateTime(2023, 1, 1);
            var finalYear = new DateTime(2023, 12, 31);

            var result = await (
                from mv in _context.MovimientoInventarios
                join p in _context.Personas on mv.IdClienteFk equals p.Id
                where mv.IdTipoMovimientoInventarioFk == 1
                where p.IdRolFk == 3
                where mv.FechaMovimiento >= inicioYear && mv.FechaMovimiento <= finalYear
                group p by new { p.Id, p.Nombre, p.Documento } into grouped
                select new
                {
                    IdProveedor = grouped.Key.Id,
                    NombreProveedor = grouped.Key.Nombre,
                    DocumentoProveedor = grouped.Key.Documento,
                    VecesSuministradas = grouped.Count()
                }
            ).ToListAsync();

            return result;
        }

        //CONSULTA 32: Empleado que ha vendido la mayor cantidad de medicamentos distintos en 2023.
        public async Task<object> GetEmployeeMediSold2023()
        {
            var year = 2023;

            var consulta = (
                from mv in _context.MovimientoInventarios
                join p in _context.Personas on mv.IdVendedorFk equals p.Id
                where mv.IdTipoMovimientoInventarioFk == 2 &&
                      mv.FechaMovimiento.Year == year
                where p.IdRolFk == 2
                group mv by new { p.Id, p.Nombre } into grouped
                orderby grouped.Select(mv => mv.IdInventarioFk).Distinct().Count() descending
                select new
                {
                    IdVendedor = grouped.Key.Id,
                    NombreVendedor = grouped.Key.Nombre,
                    DistinctMedicinesSoldCount = grouped.Select(mv => mv.IdInventarioFk).Distinct().Count()
                }
            ).FirstOrDefaultAsync();

            return await consulta;
        }

        //CONSULTA 34: Medicamentos que no han sido vendidos en 2023.
        public async Task<IEnumerable<object>> GetMediNotSold2023()
{
    var medicamentosDisponibles = await (
        from i in _context.Inventarios
        join di in _context.DetalleMovInventarios on i.Id equals di.IdInventarioFk
        join mv in _context.MovimientoInventarios on di.IdMovimientoInvFk equals mv.Id
        where mv.IdTipoMovimientoInventarioFk == 2
        where mv.FechaMovimiento.Year == 2023
        select i.Id
    ).Distinct().ToListAsync();

    var todosLosMedicamentos = await (
        from i in _context.Inventarios
        select i.Id
    ).ToListAsync();

    var medicamentosNoVendidosEn2023 = todosLosMedicamentos.Except(medicamentosDisponibles);

    var medicamentosNoVendidos = await (
        from i in _context.Inventarios
        where medicamentosNoVendidosEn2023.Contains(i.Id)
        select new
        {
            MedicamentoId = i.Id,
            NombreMedicamento = i.Nombre
        }
    ).ToListAsync();

    return medicamentosNoVendidos;
}

//CONSULTA 36: Total de medicamentos vendidos en el primer trimestre de 2023.

public async Task<IEnumerable<object>> GetFirstQuarterOf2023()
{
    var Trimestre = await (
        from di in _context.DetalleMovInventarios
        join i in _context.Inventarios on di.IdInventarioFk equals i.Id
        join mv in _context.MovimientoInventarios on di.IdMovimientoInvFk equals mv.Id
        where mv.IdTipoMovimientoInventarioFk == 2
        where mv.FechaMovimiento.Year == 2023
        where mv.FechaMovimiento.Month >= 1 && mv.FechaMovimiento.Month <= 3 
        group new { mv, i, di } by new { mv.FechaMovimiento.Year, primertri = 1 } into grouped 
        select new
        {
            Quarter = grouped.Key.primertri,
            TotalMedicinesSold = grouped.Sum(item => item.di.Cantidad),
            Medicamentos = grouped.Select(item => new
            {
                MedicamentoId = item.i.Id,
                nombre = item.i.Nombre,
                CantidadVendida = item.di.Cantidad
            }).ToList()
        }
    ).ToListAsync();

    return Trimestre;
}








    }
}