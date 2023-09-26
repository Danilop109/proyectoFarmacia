
namespace Dominio.Interfaces
{
    public interface IUnitOfWork 
    {
        ICiudad Ciudades {get;}
        IContactoPersona ContactosPersonas {get;}
        IDepartamento Departamentos {get;}
        IDetalleMovInventario DetalleMovInventarios {get;}
        IDireccion Direcciones {get;}
        IFormaPago FormasPagos {get;}
        IInventario Inventarios {get;}
        IMarca Marcas {get;}
        IMedicamentoRecetado MedicamentoRecetados {get;}
        IMovimientoInventario MovimientoInventarios {get;}
        IPais Paises {get;}
        IPersona Personas {get;}
        IPresentacion Presentaciones {get;}
        IProducto Productos {get;}
        IProductoProveedor ProductoProveedores {get;}
        IRecetaMedica RecetaMedicas {get;}
        IRol Rols {get;}
        ITipoContacto TipoContactos {get;}
        ITipoDocumento TipoDocumentos {get;}
        ITipoMovInventario TipoMovInventarios {get;}
        ITipoPersona TipoPersonas {get;}
        IUser Users {get;}

        Task<int> SaveAsync();
    }
}