using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventario
    {
        public MovimientoInventarioRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}