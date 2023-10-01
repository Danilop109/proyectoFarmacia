using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositorio
{
    public class TipoMovInventarioRepository : GenericRepository<TipoMovInventario>, ITipoMovInventario
    {
        private readonly ApiFarmaciaContext _context;

        public TipoMovInventarioRepository(ApiFarmaciaContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<TipoMovInventario>> GetAllAsync()
        {
            return await _context.TipoMovInventarios
                .ToListAsync();
        }

        public override async Task<TipoMovInventario> GetByIdAsync(int id)
        {
            return await _context.TipoMovInventarios
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}