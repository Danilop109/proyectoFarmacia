using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class DetalleMovInventarioDto
    {
        public int Id {get; set;}
        public int Cantidad {get; set;}
        public double Precio {get; set;}
        public InventarioDto Inventario {get; set;}
        public MovimientoInventarioDto MovimientoInventario {get; set;}
    }
}