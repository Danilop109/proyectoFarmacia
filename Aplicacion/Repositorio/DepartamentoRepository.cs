using Dominio.Entities;
using Persistencia;
using Dominio.Interfaces;
namespace Aplicacion.Repositorio
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
        public DepartamentoRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}