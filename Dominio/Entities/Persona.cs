

using iText.Commons.Actions;

namespace Dominio.Entities;
    public class Persona : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento {get; set;}
        public DateTime FechaRegistro {get; set;}
        public int IdTipoPersonaFk {get; set;}
        public TipoPersona TipoPersona {get; set;}
        public int IdTipoDocumentoFk {get; set;}
        public TipoDocumento TipoDocumento {get; set;}
        public int IdRolFk {get; set;}
        public Rol Rol {get; set;}
        public int IdMovimientoInventarioFk {get; set;}
        public MovimientoInventario MovimientoInventario {get; set;}
        public ICollection<Direccion> Direcciones {get; set;}
        public ICollection<RecetaMedica> DoctorCollection {get; set;}
        public ICollection<RecetaMedica> PacienteCollection {get; set;}
        public ICollection<MovimientoInventario> ReceptorCollection { get; set; }
        public ICollection<ContactoPersona> ContactoPersonas {get; set;}
        public ICollection<Producto> Productos {get; set;} = new HashSet<Producto>();
        public ICollection<ProductoProveedor> ProductoProveedores {get;set;}
        public virtual User User {get; set;}
  
}
