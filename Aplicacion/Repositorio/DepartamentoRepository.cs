using Dominio.Entities;
using Persistencia;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Aplicacion.Repositorio
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
    
    private readonly ApiFarmaciaContext _context;
        public DepartamentoRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }
    
    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos
        .Include(p => p.Pais)
        .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos
        .Include(p => p.Pais)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    }
}