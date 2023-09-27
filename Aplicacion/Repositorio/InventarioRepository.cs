using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        public InventarioRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}