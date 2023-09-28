using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiFarmacia.Dtos
{
    public class MedicamentoRecetadoDto
    {
        public int Id {get; set;}
        public string Descripcion {get; set;}
        public RecetaMedicaDto RecetaMedica {get; set;}
        public InventarioDto Inventario{get; set;}
    }
}