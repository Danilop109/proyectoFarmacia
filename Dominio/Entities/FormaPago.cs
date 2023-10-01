
namespace Dominio.Entities;
    public class FormaPago : BaseEntity
    {
        public string Nombre {get; set;}   

        public int IdMovimientoInventarioFk {get; set;}
        public MovimientoInventario MovimientoInventario{get; set;}
    }
