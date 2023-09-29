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
    public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
        private readonly ApiFarmaciaContext _context;

        public ProductoRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos
            .Include(p => p.Marca)
            .Include(p => p.Inventario)
            .ToListAsync();
        }

        public override async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos
            .Include(p => p.Marca)
            .Include(p => p.Inventario)
            .FirstOrDefaultAsync(p => p.Id == id );
        }

<<<<<<< HEAD
         //Medicamentos comprados a un provedor (x)

        public async Task<IEnumerable<Producto>> MedicamentosCompradosPorProveedor(string nombre)
        {
            return await _context.Productos
                            .Where(product =>
                            product.ProductoProveedores.Any(compraProducto =>
                            compraProducto.Proveedor.Nombre.ToUpper() == nombre.ToUpper() ))
                            //.Include(p => p.ProductoProveedores)
                            .ToListAsync();
=======
        public async Task<IEnumerable<Producto>> GetMediExpireBeforeDate(DateTime expireDate)
        {
            return await _context.Productos
                        .Where(d => d.FechaCaducidad.Date <= expireDate)
                        .ToListAsync();
        }
>>>>>>> 0758ef3057c78aa3976eff085edd50ccd4ef57e6

    }
}
}