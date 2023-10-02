using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IMovimientoInventario : IGenericRepository<MovimientoInventario>
    {
        Task<double> MediTotalSales();
        Task<IEnumerable<Persona>> GetPatientParacetamol();
        Task<IEnumerable<object>> GetMediSale2023();
        Task<IEnumerable<object>> GainProvee2023();
        Task<IEnumerable<object>> GetCountSales();
        Task<IEnumerable<object>> GetCountMoreThan5Sales();
        Task<IEnumerable<object>> GetProveeMoreMedi2023();
        Task<IEnumerable<object>> GetTotalMediSoldByMonth();
        
    }
}