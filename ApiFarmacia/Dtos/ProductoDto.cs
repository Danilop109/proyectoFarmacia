using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public double Precio {get; set;}
        public int Cantidad {get; set;}
        public List<ProveedorDto> Proveedores{ get; set; }
    }
}