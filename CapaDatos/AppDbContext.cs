using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ProductoRepository
    {
        private readonly AppDbContext _context; // Usamos el contexto  

        public ProductoRepository()
        {
            _context = new AppDbContext(); // Instancia del contexto  
        }

        public List<Producto> ObtenerTodos()
        {
            return _context.Productos.ToList(); // Devuelve todos los productos  
        }

        public void Agregar(Producto producto)
        {
            _context.Productos.Add(producto); // Agrega un nuevo producto  
            _context.SaveChanges(); // Guarda los cambios  
        }

        public Producto ObtenerPorId(int id)
        {
            return _context.Productos.Find(id); // Busca un producto por su ID  
        }

        public void Actualizar(Producto producto)
        {
            _context.Productos.Update(producto); // Actualiza un producto existente  
            _context.SaveChanges(); // Guarda los cambios  
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id); // Busca el producto por ID  
            if (producto != null)
            {
                _context.Productos.Remove(producto); // Elimina el producto  
                _context.SaveChanges(); // Guarda los cambios  
            }
        }
    }
}