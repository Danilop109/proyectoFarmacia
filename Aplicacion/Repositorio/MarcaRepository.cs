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
    public class MarcaRepository : GenericRepository<Marca>, IMarca
    {
        private readonly ApiFarmaciaContext _context;
        public MarcaRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Marca>> GetAllAsync()
        {
            return await _context.Marcas
            .ToListAsync();
            
        }

        public override async Task<Marca> GetByIdAsync(int id)
        {
            return await _context.Marcas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}