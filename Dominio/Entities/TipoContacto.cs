using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class TipoContacto : BaseEntity
    {
        public string Nombre {get; set;}
        public ICollection<ContactoPersona> ContactosPersonas {get; set;}
    }
}