using System.Globalization;
using Dominio.Entities;
using Dominio.Interfaces;
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

        //CONSULTA 26: Total de medicamentos vendidos por mes en 2023.
        public async Task<IEnumerable<object>> GetTotalMediSoldByMonth()
        {

            return await (
                from mv in _context.MovimientoInventarios
                where mv.IdTipoMovimientoInventarioFk == 2
                where mv.FechaMovimiento.Year == 2023
                group mv by new { mv.FechaMovimiento.Year, mv.FechaMovimiento.Month } into grouped
                select new
                {
                    Year = grouped.Key.Year,
                    Month = grouped.Key.Month,
                    TotalMedicinesSold = grouped.Count()
                }
            ).ToListAsync();
        }



    }
}