using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class TipoMovInventarioRepository : GenericRepository<TipoMovInventario>, ITipoMovInventario
    {
        public TipoMovInventarioRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}