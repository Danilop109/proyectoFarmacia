using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IMovimientoInventario : IGenericRepository<MovimientoInventario>
    {
        Task<double> MediTotalSales();
        Task<IEnumerable<Persona>> GetPatientParacetamol();
    }
}