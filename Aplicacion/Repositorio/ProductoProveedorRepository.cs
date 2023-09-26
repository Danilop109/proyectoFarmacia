using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class ProductoProveedorRepository : GenericRepository<ProductoProveedor>, IProductoProveedor
    {
        public ProductoProveedorRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}