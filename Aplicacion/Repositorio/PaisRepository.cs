using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly ApiFarmaciaContext _context;
    public PaisRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises
        .Include(p => p.Departamentos)
        .ToListAsync();
    }

    public override async Task<Pais> GetByIdAsync(int id)
    {
        return await _context.Paises
        .Include(p => p.Departamentos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }


}
