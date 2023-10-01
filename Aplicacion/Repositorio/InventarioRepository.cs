using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        private readonly ApiFarmaciaContext _context;
        public InventarioRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Inventario>> GetAllAsync()
        {
            return await _context.Inventarios
            .Include(p => p.Presentacion)
            .ToListAsync();
        }

        public override async Task<Inventario> GetByIdAsync(int id)
        {
            return await _context.Inventarios
            .Include(p => p.Presentacion )
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        //CONSULTA 1: Obtener todos los medicamentos con menos de (x) unidades en stock

        public async Task<IEnumerable<Inventario>> ObtenerMenosStockAsync(int cantidad)
        {
            return await _context.Inventarios
            .Where(p => p.Stock < cantidad)
            .ToListAsync();
        }


    }
}