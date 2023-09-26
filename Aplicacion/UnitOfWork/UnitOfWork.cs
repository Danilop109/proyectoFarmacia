using Aplicacion.Repositorio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiFarmaciaContext _context;
        private CiudadRepository _ciudades;
        private ContactoPersonaRepository _contactoPersonas;
        private DepartamentoRepository _departamentos;
        private DetalleMovInventarioRepository _detalleMovInventarios;
        private DireccionRepository _direcciones;
        private FormaPagoRepository _formaPagos;
        private InventarioRepository _inventarios;
        private MarcaRepository _marcas;
        private MedicamentoRecetadoRepository _medicamentoRecetados;
        private MovimientoInventarioRepository _movimientoInventarios;
        private PaisRepository _paises;
        private PersonaRepository _personas;
        private PresentacionRepository _presentaciones;
        private ProductoRepository _productos;
        private ProductoProveedorRepository _productoProveedores;
        private RecetaMedicaReporitory _recetaMedicas;
        private RolRepository _rols;
        private TipoContactoRepository _tipoContactos;
        private TipoDocumentoRepository _tipoDocumentos;
        private TipoMovInventarioRepository _tipoMovInventarios;
        private TipoPersonaRepository _tipoPersonas;
        private UserRepository _users;

        public UnitOfWork(ApiFarmaciaContext context)
        {
            _context = context;
        }

        public ICiudad Ciudades
        {
            get
            {
                if (_ciudades == null)
                {
                    _ciudades = new CiudadRepository(_context);
                }
                return _ciudades;
            }
        }


        public IContactoPersona ContactoPersonas
        {
        get
        {
            if(_contactoPersonas == null)
            {
                _contactoPersonas = new ContactoPersonaRepository(_context);
            }
            return _contactoPersonas;
        }
        }

        public IDepartamento Departamentos
        {
        get
        {
            if(_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
        }

        public IDetalleMovInventario DetalleMovInventarios
        {
        get
        {
            if(_detalleMovInventarios == null)
            {
                _detalleMovInventarios = new DetalleMovInventarioRepository (_context);
            }
            return _detalleMovInventarios;
        }
        }

        public IDireccion Direcciones
        {
        get
        {
            if(_direcciones == null)
            {
                _direcciones = new DireccionRepository(_context);
            }
            return _direcciones;
        }
        }

        public IFormaPago FormaPagos
        {
        get
        {
            if(_formaPagos == null)
            {
                _formaPagos = new FormaPagoRepository(_context);
            }
            return _formaPagos;
        }    
        }

        public IInventario Inventarios
        {
        get
        {
            if(_inventarios == null)
            {
               _inventarios = new InventarioRepository(_context);
            }
            return _inventarios;
        }    
        }

        public IMarca Marcas
        {
        get
        {
            if(_marcas == null)
            {
               _marcas = new MarcaRepository(_context);
            }
            return _marcas;
        }    
        }

        public IMedicamentoRecetado MedicamentoRecetados
        {
        get
        {
            if(_medicamentoRecetados == null)
            {
               _medicamentoRecetados = new MedicamentoRecetadoRepository(_context);
            }
            return _medicamentoRecetados;
        }    
        }

        public IMovimientoInventario MovimientoInventarios
        {
        get
        {
            if(_movimientoInventarios == null)
            {
               _movimientoInventarios = new MovimientoInventarioRepository(_context);
            }
            return _movimientoInventarios;
        }    
        }

        public IPais Paises
        {
        get
        {
            if(_paises == null)
            {
               _paises = new PaisRepository(_context);
            }
            return _paises;
        }    
        }

        public IPersona Personas
        {
        get
        {
            if(_personas == null)
            {
               _personas = new PersonaRepository(_context);
            }
            return _personas;
        }    
        }

        public IPresentacion Presentaciones
        {
        get
        {
            if(_presentaciones == null)
            {
               _presentaciones = new PresentacionRepository(_context);
            }
            return _presentaciones;
        }    
        }

        public IProducto Productos
        {
        get
        {
            if(_productos == null)
            {
               _productos = new ProductoRepository(_context);
            }
            return _productos;
        }    
        }

        public IProductoProveedor ProductoProveedores
        {
        get
        {
            if(_productoProveedores == null)
            {
               _productoProveedores = new ProductoProveedorRepository(_context);
            }
            return _productoProveedores;
        }    
        }

        public IRecetaMedica RecetaMedicas
        {
        get
        {
            if(_recetaMedicas == null)
            {
               _recetaMedicas = new RecetaMedicaReporitory(_context);
            }
            return _recetaMedicas;
        }    
        }

        public IRol Rols
        {
        get
        {
            if(_rols == null)
            {
               _rols = new RolRepository(_context);
            }
            return _rols;
        }    
        }

        public ITipoContacto TipoContactos
        {
        get
        {
            if(_tipoContactos == null)
            {
               _tipoContactos = new TipoContactoRepository(_context);
            }
            return _tipoContactos;
        }    
        }
        
        public ITipoDocumento TipoDocumentos
        {
        get
        {
            if(_tipoDocumentos == null)
            {
               _tipoDocumentos = new TipoDocumentoRepository(_context);
            }
            return _tipoDocumentos;
        }    
        }

        public ITipoMovInventario TipoMovInventarios
        {
        get
        {
            if(_tipoMovInventarios == null)
            {
               _tipoMovInventarios = new TipoMovInventarioRepository(_context);
            }
            return _tipoMovInventarios;
        }    
        }

        public ITipoPersona TipoPersonas
        {
        get
        {
            if(_tipoPersonas == null)
            {
               _tipoPersonas = new TipoPersonaRepository(_context);
            }
            return _tipoPersonas;
        }    
        }

        public IUser Users
        {
        get
        {
            if(_users == null)
            {
               _users = new UserRepository(_context);
            }
            return _users;
        }    
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

    }
