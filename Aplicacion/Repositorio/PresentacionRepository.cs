using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacion
    {
        public PresentacionRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}