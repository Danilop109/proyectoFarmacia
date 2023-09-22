

namespace Dominio.Entities;
    public class Inventario : BaseEntity
    {
        public string Nombre {get;set;}
        public int Stock {get; set;}
        public int StockMin {get; set;}
        public int StockMax {get; set;}
        public DateTime FechaExpiracion {get; set;}
        public int IdPresentacionFk {get; set;}
        public Presentacion Presentacion {get; set;}
        public ICollection<DetalleMovInventario> DetalleMovInventarios {get; set;}
        public ICollection<Producto> Productos {get; set;}
        public ICollection<MedicamentoRecetado> MedicamentoRecetados {get; set;}
    }
