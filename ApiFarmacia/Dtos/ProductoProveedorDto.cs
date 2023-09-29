using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class ProductoProveedorDto
    {
        public int Id { get; set; }
<<<<<<< HEAD
        // public DateTime FechaCompra {get;set;}
        // public MovimientoInventarioDto MovimientoInventarioDto {get;set;}

        public ProductoDto ProductoDto{ get; set; }
        public ProveedorDto ProveedorDto{ get; set;}


=======
        public ProductoDto Producto{ get; set; }
        public ProveedorDto Proveedor{ get; set;}
>>>>>>> 0758ef3057c78aa3976eff085edd50ccd4ef57e6
    }
}