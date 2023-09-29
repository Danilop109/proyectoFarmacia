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
    public class RecetaMedicaReporitory : GenericRepository<RecetaMedica>, IRecetaMedica
    {
        private readonly ApiFarmaciaContext _context;

        public RecetaMedicaReporitory(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<RecetaMedica>> GetAllAsync()
        {
            return await _context.RecetaMedicas
            .Include(p => p.DoctorFk)
            .Include(p => p.PacienteFk)
            .ToListAsync();
        }

        public override async Task<RecetaMedica> GetByIdAsync(int id)
        {
            return await _context.RecetaMedicas
            .Include(p => p.DoctorFk)
            .Include(p => p.PacienteFk)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<RecetaMedica>> GetRecetaSinceDate(DateTime date)
        {
                return await _context.RecetaMedicas
                            .Where (d => d.FechaEmicion.Date >= date.Date)
                            .Include(m => m.MedicamentoRecetados).ThenInclude(m => m.Inventario)
                            .Include(d => d.DoctorFk)
                            .Include(d => d.PacienteFk)
                            .ToListAsync();
             
        }
    }
}