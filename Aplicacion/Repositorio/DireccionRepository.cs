using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class DireccionRepository : GenericRepository<Direccion>, IDireccion
    {
        private readonly ApiFarmaciaContext _context;
        public DireccionRepository(ApiFarmaciaContext context) : base(context)
        {
             _context = context;
        }

        public override async Task<IEnumerable<Direccion>> GetAllAsync()
        {
            return await _context.Direcciones
            .Include(p => p.Ciudad)
            .Include(p => p.Persona)
            .ToListAsync();
        }

        public override async Task<Direccion> GetByIdAsync(int id)
        {
            return await _context.Direcciones
            .Include(p => p.Ciudad)
            .Include(p => p.Persona)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}