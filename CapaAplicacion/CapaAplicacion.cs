using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class CapaAplicacion
    {

        public class ProductoRepository
        {
            private readonly ProductoRepository _productoRepository;

            public ProductoRepository(ProductoRepository productoRepository)
            {
                _productoRepository = productoRepository;
            }

            public IEnumerable<Producto> ObtenerTodos()
            {
                return _productoRepository.ObtenerTodos();
            }

            public Producto ObtenerPorId(int id)
            {
                return _productoRepository.ObtenerPorId(id);
            }

            public void AgregarProducto(Producto producto)
            {
                // Lógica de negocio adicional antes de agregar
                _productoRepository.Agregar(producto);
            }

            private void Agregar(Producto producto)
            {
                throw new NotImplementedException();
            }

            public void ActualizarProducto(Producto producto)
            {
                // Lógica de negocio adicional antes de actualizar
                _productoRepository.Actualizar(producto);
            }

            private void Actualizar(Producto producto)
            {
                throw new NotImplementedException();
            }

            public void EliminarProducto(int id)
            {
                // Lógica de negocio adicional antes de eliminar
                _productoRepository.Eliminar(id);
            }

            private void Eliminar(int id)
            {
                throw new NotImplementedException();
            }
        }

        public class Producto
        {
        }
    }
}
