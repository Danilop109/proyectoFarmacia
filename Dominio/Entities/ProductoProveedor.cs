using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class ProductoProveedor
    {
        public string IdProveedorFk {get; set;}
        public Persona Persona {get; set;}
        public string IdProductoFk {get; set;}
        public Producto Producto {get; set;}
    }
}