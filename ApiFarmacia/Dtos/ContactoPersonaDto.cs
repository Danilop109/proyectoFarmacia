using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiFarmacia.Dtos
{
    public class ContactoPersonaDto
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Numero {get;set;}
        public PersonaDto Persona {get; set;}
        public TipoContactoDto TipoContacto{get; set;}
    }
}