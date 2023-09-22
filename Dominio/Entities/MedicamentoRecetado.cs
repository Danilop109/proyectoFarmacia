using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MedicamentoRecetado: BaseEntity
    {
        public int IdRecetaMedicaFk { get; set; }
        public RecetaMedica RecetaMedica {get; set;}
        public int IdInventarioFk {get; set;}
        public Inventario Inventario {get; set;}
        public string Descripcion {get; set;}
    }
}