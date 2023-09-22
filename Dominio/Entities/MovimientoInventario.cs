using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MovimientoInventario : BaseEntity
    {
        public DateTime FechaVencimiento {get; set;}
        public DateTime FechaMovimiento {get; set;}
        public int IdResponsable { get; set; }
        public Persona ResponsableFk {get; set;}
        public int IdReceptorFk {get; set;}
        public Persona ReceptorFk {get; set;}
        public int IdTipoMovInventarioFk {get; set;}
        public TipoMovInventario TipoMovInventario {get; set;}
        public int IdFormaPago {get; set;}
        public FormaPago FormaPago {get; set;}
        public int IdRecetaMedicaFk {get; set;}
        public RecetaMedica RecetaMedica {get; set;}
        public ICollection<DetalleMovInventario> DetalleMovInventarios {get; set;}
        public ICollection<Factura> Facturas {get; set;}


    }
}