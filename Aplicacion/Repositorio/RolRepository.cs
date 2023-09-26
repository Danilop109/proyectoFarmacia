using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        public RolRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}