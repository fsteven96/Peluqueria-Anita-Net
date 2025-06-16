using PeluqueriaAnita.Datos.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace PeluqueriaAnita.Datos.Repositorios
{
    public class CitaRepositorio
    {
        private readonly Conexion _conexion;

        public CitaRepositorio()
        {
            _conexion = new Conexion();
        }

        public async Task<List<Cita>> ObtenerCitasActivasAsync()
        {
            var lista = new List<Cita>();

            try
            {
                using (SqlConnection conn = _conexion.GetConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerCitasActivas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new Cita
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                    NombreCliente = reader.GetString(reader.GetOrdinal("Nombre")),
                                    FechaHora = reader.GetDateTime(reader.GetOrdinal("FechaHora")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear el error o manejarlo según convenga
                // Por ejemplo: logger.LogError(ex, "Error al obtener citas activas");
                throw new Exception("Error al obtener citas activas: " + ex.Message, ex);
            }

            return lista;
        }

        public async Task<bool> AgregarCitaAsync(Cita cita)
        {
            try
            {
                using (SqlConnection conn = _conexion.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AgregarCita", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ClienteId", cita.ClienteId);
                        cmd.Parameters.AddWithValue("@FechaHora", cita.FechaHora);
                        cmd.Parameters.AddWithValue("@Estado", cita.Estado);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la cita a la base de datos.", ex);
                return false;
            }
        }



    }
}
