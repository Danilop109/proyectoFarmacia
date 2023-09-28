using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class ProductoProveedorDto
    {
        public int Id { get; set; }
        public ProductoDto ProductoDto{ get; set; }
        public ProveedorDto ProveedorDto{ get; set;}
    }
}