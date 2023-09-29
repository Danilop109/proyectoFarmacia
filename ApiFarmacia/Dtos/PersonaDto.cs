using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoFk {get; set;}
        public string Documento  {get; set; }
        public TipoPersonaDto TipoPersona {get; set; }
        public RolDto TipoRol {get; set; }

    }
}