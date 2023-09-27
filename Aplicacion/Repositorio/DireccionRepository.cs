using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class DireccionRepository : GenericRepository<Direccion>, IDireccion
    {
        public DireccionRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}