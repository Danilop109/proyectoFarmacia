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
    public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
    {
        private readonly ApiFarmaciaContext _context;

        public TipoPersonaRepository(ApiFarmaciaContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
        {
            return await _context.TipoPersonas
                .ToListAsync();
        }

        public override async Task<TipoPersona> GetByIdAsync(int id)
        {
            return await _context.TipoPersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}