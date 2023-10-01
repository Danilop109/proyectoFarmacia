using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiFarmacia.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento  {get; set; }
        public Persona ResponsableFk {get; set;}
        public Persona ReceptorFk {get; set;}
        public RolDto Rol {get; set;} 
        public TipoDocumentoDto TipoDocumento{get;set;}
        public TipoPersonaDto TipoPersona {get; set; }
   
    }
}