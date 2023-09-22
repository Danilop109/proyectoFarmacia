using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class ContactoPersona : BaseEntity
    {
        public string Nombre {get; set;}
        public string Numero {get; set;}
        public int PersonaIdFk {get; set;}
        public Persona Persona {get; set;}
        public int IdTipoContactoFk {get; set;}
        public TipoContacto TipoContacto {get; set;}
    }
}