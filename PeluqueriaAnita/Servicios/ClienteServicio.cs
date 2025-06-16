using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Datos.Repositorios;

namespace PeluqueriaAnita.Servicios
{
    public class ClienteServicio
    {
        private readonly ClienteRepositorio clienteRepositorio;

        public ClienteServicio(ClienteRepositorio clienteRepositorio)
        {
            this.clienteRepositorio = clienteRepositorio;
        }

        public List<Cliente> ObtenerTodos()
        {
            return clienteRepositorio.ObtenerClientesAsync().Result;
        }

        public async Task<bool> AgregarClienteAsync(Cliente cliente)
        {
            return await clienteRepositorio.AgregarClienteAsync(cliente);
        }

    }
}
