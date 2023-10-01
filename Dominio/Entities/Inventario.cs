

namespace Dominio.Entities;
    public class Inventario : BaseEntity
    {
        public string Nombre {get;set;}
        public int Stock {get; set;}
        public int StockMin {get; set;}
        public int StockMax {get; set;}
        public int IdPresentacionFk {get; set;}
        public Presentacion Presentacion {get; set;}
        
        public int IdDetalleMovInventarioFk {get; set;}
        public DetalleMovInventario DetalleMovInventario {get;set;}
        public ICollection<Producto> Productos {get; set;}
        public ICollection<MedicamentoRecetado> MedicamentoRecetados {get; set;}
        public ICollection<RecetaMedica> RecetaMedicas {get; set;}
    }
