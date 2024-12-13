using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class producto
    {
        public class ProductoRepository
        {
            private readonly BoticaContext _context;

            public object EntityState { get; private set; }

            public ProductoRepository(BoticaContext context)
            {
                _context = context;
            }

            public IEnumerable<Producto> ObtenerTodos() => _context.Productos.Include(p => p.Categoria).Include(p => p.Proveedor).ToList();

            public Producto ObtenerPorId(int id) => _context.Productos.Include(p => p.Categoria).Include(p => p.Proveedor).FirstOrDefault(p => p.Id == id);

            public void Agregar(Producto producto)
            {
                object value = _context.Productos.Add(producto);
                _context.SaveChanges();
            }

            public void Actualizar(Producto producto)
            {
                _context.Entry(producto).State = EntityState;
                _context.SaveChanges();
            }

            public void Eliminar(int id)
            {
                var producto = _context.Productos.Find(id);
                if (producto != null)
                {
                    object value = _context.Productos.Remove(producto);
                    _context.SaveChanges();
                }
            }
        }
    }
}
