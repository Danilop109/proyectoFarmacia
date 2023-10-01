using Dominio.Entities;
using Persistencia;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositorio
{
    public class DetalleMovInventarioRepository : GenericRepository<DetalleMovInventario>, IDetalleMovInventario
    {
        private readonly ApiFarmaciaContext _context;
        public DetalleMovInventarioRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<DetalleMovInventario>> GetAllAsync()
        {
            return await _context.DetalleMovInventarios
            .Include(p => p.MovimientoInventario)
            .ToListAsync();
        }

        public override async Task<DetalleMovInventario> GetByIdAsync(int id )
        {
            return await _context.DetalleMovInventarios
            .Include(p => p.MovimientoInventario)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}