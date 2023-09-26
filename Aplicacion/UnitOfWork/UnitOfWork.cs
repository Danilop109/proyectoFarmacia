using Aplicacion.Repositorio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(ApiFarmaciaContext context)
        {
            context = _context;
        }
        private readonly ApiFarmaciaContext _context;
        public CiudadRepository _ciudades;

        public ContactoPersonaRepository _contactosPersonas;

        public DepartamentoRepository _departamentos;

        public DetalleMovInventarioRepository _detalleMovInventarios;

        public DireccionRepository _direcciones;

        public FormaPagoRepository _formasPagos;

        public InventarioRepository _inventarios;

        public MarcaRepository _marcas;

        public MedicamentoRecetadoRepository _medicamentoRecetados;

        public MovimientoInventarioRepository _movimientoInventarios;

        public PaisRepository _paises;

        public PersonaRepository _personas;

        public PresentacionRepository _presentaciones;

        public ProductoRepository _productos;

        public ProductoProveedorRepository _productoProveedores;

        public RecetaMedicaReporitory _recetaMedicas;

        public RolRepository _rols;

        public TipoContactoRepository _tipoContactos;

        public TipoDocumentoRepository _tipoDocumentos;

        public TipoMovInventarioRepository _tipoMovInventarios;

        public TipoPersonaRepository _tipoPersonas;

        public UserRepository _users;


        public ICiudad Ciudad
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


        public IContactoPersona ContactoPersona
        {
        get
        {
            if(_contactosPersonas == null)
            {
                _contactosPersonas = new ContactoPersonaRepository(_context);
            }
            return _contactosPersonas;
        }
        }

        public IDepartamento Departamento
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

        public IDetalleMovInventario DetalleMovInventario
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

        public IDireccion Direccion
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

        public IFormaPago FormaPago
        {
        get
        {
            if(_formasPagos == null)
            {
                _formasPagos = new FormaPagoRepository(_context);
            }
            return _formasPagos;
        }    
        }

        public IInventario Inventario
        {
        get
        {
            if(_inventarios == null)
            {
               _inventarios == new InventarioRepository(_context);
            }
            return _inventarios;
        }    
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    }
