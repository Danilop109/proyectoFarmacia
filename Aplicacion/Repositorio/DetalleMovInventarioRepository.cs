using Dominio.Entities;
using Persistencia;
using Dominio.Interfaces;

namespace Aplicacion.Repositorio
{
    public class DetalleMovInventarioRepository : GenericRepository<DetalleMovInventario>, IDetalleMovInventario
    {
        public DetalleMovInventarioRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}