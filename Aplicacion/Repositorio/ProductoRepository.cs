using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        //CONSULTA 3: Medicamentos comprados a un provedor (x)

        public async Task<IEnumerable<Producto>> MedicamentosCompradosPorProveedor(string nombre)
        {
            return await _context.Productos
                            .Where(product =>
                            product.ProductoProveedores.Any(compraProducto =>
                            compraProducto.Persona.Nombre.ToUpper() == nombre.ToUpper() ))
                            //.Include(p => p.ProductoProveedores)
                            .ToListAsync();

        }
        //CONSULTA 6: Medicamentos que caducan antes del 1 de enero de 2024.
        public async Task<IEnumerable<Producto>> GetMediExpireBeforeDate()
        {
            DateTime expireDate = DateTime.Parse("January 01, 2024", CultureInfo.InvariantCulture);
            return await _context.Productos
                        .Where(d => d.FechaCaducidad <= expireDate)
                        .ToListAsync();
        }

        //Obtener el medicamento más caro.
        public async Task<Producto> MediMoreExpensive()
        {
            return await _context.Productos.OrderByDescending(d => d.Precio)
            .FirstOrDefaultAsync();
        }

        // CONSULTA 28: Medicamentos con un precio mayor a 50 y un stock menor a 100.
        public async Task<IEnumerable<Producto>> GetProductosPrecioMayorA50StockMenorA100()
        {
            return await _context.Productos
            .Where(p => p.Precio > 50 && p.Inventario.Stock < 100)
            .ToListAsync();
        }

        
        // CONSULTA 7: Total de medicamentos vendidos por cada proveedor.
       public async Task<IEnumerable<object>> GetTotMediVenProveedor()
{
    var resultado = await (
        from pp in _context.ProductoProveedores
        join pro in _context.Personas on pp.IdPersonaFk equals pro.Id
        join p in _context.Productos on pp.IdProductoFk equals p.Id
        join i in _context.Inventarios on p.IdInventarioFk equals i.Id
        where pro.IdRolFk == 3
        group p by new { pro.Id, pro.Nombre } into grouped 
        select new
        {
            ProviderId = grouped.Key.Id,
            ProviderName = grouped.Key.Nombre,
            TotalProductos = grouped.Count()
        }
    ).ToListAsync();

    return resultado;
}
}
}