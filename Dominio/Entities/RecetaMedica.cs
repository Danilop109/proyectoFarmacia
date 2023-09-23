

namespace Dominio.Entities;
    public class RecetaMedica : BaseEntity
    {
        public DateOnly FechaEmicion {get; set;}
        public DateOnly FechaCaducidad {get; set;}
        public int IdDoctorFk {get; set;}
        public Persona DoctorFk {get;set;}
        public int IdPacienteFk {get; set;}
        public Persona PacienteFk {get;set;}
        public string Detalle {get; set;}
        public ICollection<MedicamentoRecetado> MedicamentoRecetados {get; set;}
        public ICollection<Inventario> Inventarios {get; set;} = new HashSet<Inventario>();
    }
