using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class InventarioDto
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public int Stock {get; set;}
        public int StockMin {get; set;}
        public int StockMax {get; set;}
        public DateTime FechaExpiracion {get; set;}
        public int IdPresentacionFk {get; set;}

        

        

    }
}