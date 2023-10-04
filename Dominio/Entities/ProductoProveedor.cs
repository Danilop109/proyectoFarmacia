using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class ProductoProveedor : BaseEntity
    {
        public int IdPersonaFk {get; set;}
        public Persona Persona {get; set;}
        public int IdProductoFk {get; set;}
        public Producto Producto {get; set;}
    }
}