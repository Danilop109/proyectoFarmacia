
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class AppFarmaciaContext : DbContext
{
    public AppFarmaciaContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    
}
