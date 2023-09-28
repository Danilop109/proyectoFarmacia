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
    public class TipoContactoRepository : GenericRepository<TipoContacto>, ITipoContacto
    {
        private readonly ApiFarmaciaContext _context;

        public TipoContactoRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<TipoContacto>> GetAllAsync()
        {
            return await _context.TipoContactos
                .ToListAsync();
        }

        public override async Task<TipoContacto> GetByIdAsync(int id)
        {
            return await _context.TipoContactos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}