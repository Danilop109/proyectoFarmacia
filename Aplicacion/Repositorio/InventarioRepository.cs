using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        private readonly ApiFarmaciaContext _context;
        public InventarioRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Inventario>> GetAllAsync()
        {
            return await _context.Inventarios
            .Include(p => p.Presentacion)
            .ToListAsync();
        }

        public override async Task<Inventario> GetByIdAsync(int id)
        {
            return await _context.Inventarios
            .Include(p => p.Presentacion )
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}