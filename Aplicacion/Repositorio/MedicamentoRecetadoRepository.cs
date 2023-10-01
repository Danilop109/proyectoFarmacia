using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class MedicamentoRecetadoRepository : GenericRepository<MedicamentoRecetado>, IMedicamentoRecetado
    {
        private readonly ApiFarmaciaContext _context;
        public MedicamentoRecetadoRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<MedicamentoRecetado>> GetAllAsync()
        {
            return await _context.MedicamentoRecetados
            .Include(p => p.RecetaMedica)
            .Include(p => p.Inventario)
            .ToListAsync();
        }

        public override async Task<MedicamentoRecetado> GetByIdAsync(int id)
        {
            return await _context.MedicamentoRecetados
            .Include(p => p.RecetaMedica)
            .Include(p => p.Inventario)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}