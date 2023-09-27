using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class MedicamentoRecetadoRepository : GenericRepository<MedicamentoRecetado>, IMedicamentoRecetado
    {
        public MedicamentoRecetadoRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}