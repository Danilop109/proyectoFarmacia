using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
    {
        public CiudadRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}