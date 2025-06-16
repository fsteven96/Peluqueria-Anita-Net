using PeluqueriaAnita.Datos.Modelos;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace PeluqueriaAnita.Datos.Repositorios
{
    public class ClienteRepositorio
    {
        private readonly Conexion _conexion;

        public ClienteRepositorio()
        {
            _conexion = new Conexion();
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            var lista = new List<Cliente>();

            using (SqlConnection conn = _conexion.GetConnection())
            {
                await conn.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", conn))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Cliente
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Telefono = reader.GetString(2)
                        });
                    }
                }
            }

            return lista;
        }


        public async Task<bool> AgregarClienteAsync(Cliente cliente)
        {
            try
            {
                using (SqlConnection conn = _conexion.GetConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_AgregarCliente", conn))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@Telefono", (object)cliente.Telefono ?? DBNull.Value);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear el error si quieres, por ejemplo con Console.WriteLine o ILogger
                Console.WriteLine("Error al agregar cliente: " + ex.Message);
                return false;
            }
        }


    }
}
