using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using iText.Barcodes.Dmcode;
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
            .Include(p => p.MovimientoInventario)
            .ToListAsync();
        }

        public override async Task<RecetaMedica> GetByIdAsync(int id)
        {
            return await _context.RecetaMedicas
            .Include(p => p.DoctorFk)
            .Include(p => p.PacienteFk)
            .Include(p => p.MovimientoInventario)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        // CONSULTA 4: Obtener recetas médicas emitidas después del 1 de enero de 2023.
        public async Task<IEnumerable<RecetaMedica>> GetRecetaSinceDate()
        {
            DateTime date = DateTime.Parse("January 01, 2023", CultureInfo.InvariantCulture);
            return await _context.RecetaMedicas
                            .Where (d => d.FechaEmicion >= date)
                            .Include(m => m.MedicamentoRecetados).ThenInclude(m => m.Inventario)
                            .Include(d => d.DoctorFk)
                            .Include(p => p.PacienteFk)
                            .ToListAsync();
        }

        
    
    }
}