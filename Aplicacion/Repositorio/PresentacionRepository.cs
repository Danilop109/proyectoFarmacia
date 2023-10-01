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
    public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacion
    {
        private readonly ApiFarmaciaContext _context;

        public PresentacionRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Presentacion>> GetAllAsync()
        {
            return await _context.Presentaciones.ToListAsync();
        }

        public override async Task<Presentacion> GetByIdAsync(int id)
        {
            return await _context.Presentaciones.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}