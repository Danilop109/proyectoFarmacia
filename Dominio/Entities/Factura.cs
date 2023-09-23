using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Factura : BaseEntity
    {
        public int IdMovInventarioFk {get; set;}
        public MovimientoInventario MovimientoInventario {get; set;}
        public int IdProductoFk {get; set;}
        public Producto Producto {get; set;}
    }
