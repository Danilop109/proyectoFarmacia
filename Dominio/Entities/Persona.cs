

namespace Dominio.Entities;
    public class Persona : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento {get; set;}
        public DateTime FechaRegistro {get; set;}
        public int IdTipoPersona {get; set;}
        public TipoPersona TipoPersona {get; set;}
        public int IdTipoDocumento {get; set;}
        public TipoDocumento TipoDocumento {get; set;}
        public int IdRolFk {get; set;}
        public Rol Rol {get; set;}
        public ICollection<Direccion> Direcciones {get; set;}

    }
