
namespace Dominio.Entities;
    public class Direccion : BaseEntity
    {
        public string Descripcion {get; set;}
        public int IdCiudadFk {get; set;}
        public Ciudad Ciudad {get; set;}
        public int IdPersonaFk {get; set;}
        public Persona Persona {get; set;}
    }
