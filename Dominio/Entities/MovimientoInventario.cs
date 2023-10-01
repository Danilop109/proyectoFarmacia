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
        public ICollection<Persona> Personas {get; set;}
        public ICollection<TipoMovInventario> TipoMovInventarios{get; set;}
        public ICollection<FormaPago> FormaPagos {get; set;}
        public ICollection<RecetaMedica> RecetaMedicas {get; set;}
        public ICollection<DetalleMovInventario> DetalleMovInventarios {get; set;}
        public ICollection<Producto> Productos {get; set;} = new HashSet<Producto>();   




    }
}