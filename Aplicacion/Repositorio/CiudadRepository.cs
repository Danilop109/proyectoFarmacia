using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
    {
        public CiudadRepository(ApiFarmaciaContext context) : base(context)
        {   
        }





        // public override async Task<IEnumerable<Ciudad>> GetAllAsync()
        // {
        //     return await _context.Ciudades
        //     .Include(p => p.Departamento)
        //     .ToListAsync();
        // }

        // public override async Task<Ciudad> GetByIdAsync(string id)
        // {
        //     return await _context.Ciudades
        //     .Include(p => p.Departamento)
        //     .FirstOrDefaultAsync(p =>  p.Id == id);
        // }
    }
}