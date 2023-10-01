using System;
using System.Collections.Generic;
using System.Linq;
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

         //Medicamentos comprados a un provedor (x)

        public async Task<IEnumerable<Producto>> MedicamentosCompradosPorProveedor(string nombre)
        {
            return await _context.Productos
                            .Where(product =>
                            product.ProductoProveedores.Any(compraProducto =>
                            compraProducto.Persona.Nombre.ToUpper() == nombre.ToUpper() ))
                            //.Include(p => p.ProductoProveedores)
                            .ToListAsync();

        }
        //  Medicamentos antes de que se caduquen en una fecha
        public async Task<IEnumerable<Producto>> GetMediExpireBeforeDate(DateTime expireDate)
        {
            return await _context.Productos
                        .Where(d => d.FechaCaducidad.Date <= expireDate)
                        .ToListAsync();
        }

        //Obtener el medicamento más caro.
        public async Task<Producto> MediMoreExpensive()
        {
            return await _context.Productos.OrderByDescending(d => d.Precio)
            .FirstOrDefaultAsync();
        }

        //Obtener el total de medicamentos vendidos en marzo de 2023.
        //  public async Task<IEnumerable<Producto>> GetProductosSale(DateTime fecha)
        //  {
        //      return await (
        //          from rm in _context.Productos
        //          join mi in _context.TipoMovInventarios on rm.IdInventarioFk equals mi.Id
        //          join i in _context.Productos on rm.Id equals i.IdInventarioFk
        //          where mi.Id == 1
        //          where i.Id == 3
        //          where i.ToLower() == "paracetamol"
        //          select rm 
        //      ).ToListAsync();
        //  }

        
}
}