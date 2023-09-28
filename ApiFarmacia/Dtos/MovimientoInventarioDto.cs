using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiFarmacia.Dtos
{
    public class MovimientoInventarioDto
    {
        public int Id {get; set;}
        public DateTime FechaMovimiento {get; set;}
        public DateTime FechaVencimiento {get; set;}
        public PersonaDto Responsable {get; set;}
        public PersonaDto Receptor {get; set;}
        public FormaPagoDto FormaPago {get; set;}
        public RecetaMedicaDto RecetaMedica {get; set;}
        public TipoMovInventarioDto TipoMovInventario {get; set;}


        
    }
}