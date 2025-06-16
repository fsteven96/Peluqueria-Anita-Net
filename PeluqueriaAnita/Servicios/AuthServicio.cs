using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Datos.Repositorios;

namespace PeluqueriaAnita.Servicios
{
    public class AuthServicio
    {
        private readonly AuthRepositorio _authRepositorio;

        public AuthServicio()
        {
            _authRepositorio = new AuthRepositorio();
        }

        public Usuario ValidarUsuario(string usuario, string password)
        {
            return _authRepositorio.ValidarUsuario(usuario, password);
        }
    }
}
