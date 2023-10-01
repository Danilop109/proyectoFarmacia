using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    
    public class FormaPagoRepository : GenericRepository<FormaPago>, IFormaPago
    {
        private readonly ApiFarmaciaContext _context;
        public FormaPagoRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<FormaPago>> GetAllAsync()
        {
            return await _context.FormaPagos
            .Include(p => p.MovimientoInventario)
            .ToListAsync();
        }

        public override async Task<FormaPago> GetByIdAsync(int id)
        {
            return await _context.FormaPagos
            .Include(p => p.MovimientoInventario)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        
    }
}