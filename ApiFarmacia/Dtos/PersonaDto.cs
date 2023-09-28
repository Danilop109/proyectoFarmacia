using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string NombrePer { get; set; }
        public string ApellidoPer { get; set; }
        public int TipoDocumentoFk {get; set;}
        public string DocumentoPer  {get; set; }
        public TipoPersonaDto TipoPersona {get; set; }
        public RolDto TipoRol {get; set; }

    }
}