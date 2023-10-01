using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class DireccionDto
    {
        public int Id {get; set;}
        public string Descripcion {get; set;}
        public CiudadDto Ciudad{get; set;}
        public PersonaDto Persona {get; set;}
    }
}