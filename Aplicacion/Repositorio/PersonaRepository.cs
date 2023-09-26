using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        public PersonaRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}