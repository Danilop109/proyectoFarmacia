using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Producto : BaseEntity
    {
        public string Nombre {get; set;}
        public double Precio {get; set;}
        public int Cantidad {get; set;}
        public int IdMarcaFk {get; set;}
        public Marca Marca {get; set;}
        public int IdInventarioFk {get; set;}
        public Inventario Inventario {get; set;}
        public ICollection<ProductoProveedor> ProductoProveedores {get; set;}
        public ICollection<Persona> Personas {get; set;} = new HashSet<Persona>();


    }
}