using System.Data;
using System.Data.SqlClient;
using PeluqueriaAnita.Datos.Modelos;

namespace PeluqueriaAnita.Datos.Repositorios
{
    public class AuthRepositorio
    {

        private readonly Conexion _conexion;

        public AuthRepositorio()
        {
            _conexion = new Conexion();
        }

        public Usuario ValidarUsuario(string usuario, string password)
        {
            Usuario user = null;

            using (SqlConnection conn = _conexion.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@PasswordU", password);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UsuarioNombre = reader["Usuario"].ToString(),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Cargo = reader["Cargo"].ToString()
                            };
                        }
                    }
                }
            }

            return user;
        }

    }
}
