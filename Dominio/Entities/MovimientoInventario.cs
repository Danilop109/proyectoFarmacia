using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MovimientoInventario : BaseEntity
    {
        public DateTime FechaMovimiento {get; set;}
        public DateTime FechaVencimiento {get; set;}
        public int IdTipoMovimientoInventarioFk {get; set;}
        public TipoMovInventario TipoMovInventario {get; set;}
        public int IdVendedorFk { get; set; }
        public Persona Vendedor { get; set; }
        public int IdClienteFk { get; set; }
        public Persona Cliente { get; set; }
        public int IdRecetaMedicaFk {get; set;}
        public RecetaMedica RecetaMedica {get; set;}
        public int IdInventarioFk {get; set;}
        public Inventario Inventario {get; set;}
        public int IdFormaPagoFk {get; set; }
        public FormaPago FormaPago {get; set;}
        public ICollection<DetalleMovInventario> DetalleMovInventarios {get; set;}



    }
}