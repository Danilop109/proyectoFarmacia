using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Persistencia;
using Dominio.Interfaces;

namespace Aplicacion.Repositorio
{
    public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
    {
        public ContactoPersonaRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}