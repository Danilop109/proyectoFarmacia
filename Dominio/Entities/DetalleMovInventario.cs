using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class DetalleMovInventario: BaseEntity
    {
        public int Cantidad {get; set; }
        public double Precio {get; set;}
        public int IdInventarioFk {get; set; }
        public Inventario Inventario {get; set; }
        public int IdMovimientoInvFk {get; set; }
        public MovimientoInventario MovimientoInventario {get; set;}
    }