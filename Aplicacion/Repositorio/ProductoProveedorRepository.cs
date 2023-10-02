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
    public class ProductoProveedorRepository : GenericRepository<ProductoProveedor>, IProductoProveedor
    {
        private readonly ApiFarmaciaContext _context;

        public ProductoProveedorRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<ProductoProveedor>> GetAllAsync()
        {
            return await _context.ProductoProveedores
            .Include(p => p.Persona).ThenInclude(p => p.Rol)
            .ToListAsync();
        }

        public override async Task<ProductoProveedor> GetByIdAsync(int id)
        {
            return await _context.ProductoProveedores
            .Include(p => p.Persona).ThenInclude(p => p.TipoDocumento)
            .Include(p => p.Persona).ThenInclude(p => p.TipoPersona)
            .Include(p => p.Persona).ThenInclude(p => p.Rol)
            .Include(p => p.Producto).ThenInclude(p => p.Marca)
            .Include(p => p.Producto).ThenInclude(p => p.Inventario)
            .Include(p => p.Producto).ThenInclude(p => p.Inventario.Stock)
            .Include(p => p.Producto).ThenInclude(p => p.Inventario.Presentacion.Descripcion)
            .FirstOrDefaultAsync(p => p.Id == id);

        }
        

    }
}
