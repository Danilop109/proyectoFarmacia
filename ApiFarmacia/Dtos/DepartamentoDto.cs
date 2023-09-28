using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class DepartamentoDto
    {
        public int Id {get; set;}
        public int NombreDepartamento {get; set;}
        public PaisDto PaisDto {get;set;}

    }
}