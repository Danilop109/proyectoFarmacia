using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class FormaPagoRepository : GenericRepository<FormaPago>, IFormaPago
    {
        public FormaPagoRepository(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}