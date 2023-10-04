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
        public string Documento  {get; set; }
        public int IdRolFk {get; set;} 
        public int IdTipoDocumentoFk {get;set;}
        public int IdTipoPersonaFk {get; set; }
   
    }
}