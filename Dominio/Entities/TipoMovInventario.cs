using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class TipoMovInventario : BaseEntity
    {
        public string Nombre {get; set;}
        public int IdMovimientoInventarioFk {get; set;}
        public MovimientoInventario MovimientoInventario {get; set;}
    }
