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
            .Include(p => p.ResponsableFk)
            .Include(p =>p.ReceptorFk)
            .Include(p => p.TipoMovInventario)
            .Include(p => p.FormaPago)
            .Include(p => p.RecetaMedica)
            .ToListAsync();
        }

        public override async Task<MovimientoInventario> GetByIdAsync(int id)
        {
            return await _context.MovimientoInventarios
            .Include(p => p.ResponsableFk)
            .Include(p =>p.ReceptorFk)
            .Include(p => p.TipoMovInventario)
            .Include(p => p.FormaPago)
            .Include(p => p.RecetaMedica)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}