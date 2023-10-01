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

        //Cantidad total de dinero recaudado por las ventas de medicamentos.
    //     public async Task<double> MediTotalSales()
    // {

    //     var totalDineroVentas = await (
    //         from dm in _context.DetalleMovInventarios
    //         join d in _context.MovimientoInventarios on dm.IdMovimientoInvFk equals d.Id
    //         where d.IdTipoMovInventarioFk == 2 
    //         select dm.Cantidad * dm.Precio
    //     ).SumAsync();

    //     return totalDineroVentas;
    // }
    // //Pacientes que han comprado Paracetamol.
    // public async Task<IEnumerable<Persona>> GetPatientParacetamol()
    //     {
    //         return await (
    //             from rm in _context.MovimientoInventarios
    //             join r in _context.RecetaMedicas on rm.IdRecetaMedicaFk equals r.Id
    //             join p in _context.Personas on r.IdPacienteFk equals p.Id
    //             join i in _context.Inventarios on r.InventarioId equals i.Id
    //             where rm.IdTipoMovInventarioFk == 1
    //             where i.Id == 3
    //             where i.Nombre.ToLower() == "paracetamol"
    //             select p
                
    //             ).ToListAsync();
    //     }

    }
}