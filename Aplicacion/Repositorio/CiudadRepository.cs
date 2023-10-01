using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
    {
        private readonly ApiFarmaciaContext _context;
        public CiudadRepository(ApiFarmaciaContext context) : base(context)
        {   
            _context = context;
        }

        public override async Task<IEnumerable<Ciudad>> GetAllAsync()
         {
             return await _context.Ciudades
             .Include(p => p.Departamento)
             .ToListAsync();
        }

         public override async Task<Ciudad> GetByIdAsync(int id)
         {
             return await _context.Ciudades
             .Include(p => p.Departamento)
             .FirstOrDefaultAsync(p =>  p.Id == id);
         }
    }
