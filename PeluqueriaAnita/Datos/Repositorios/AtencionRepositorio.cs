using PeluqueriaAnita.Datos.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace PeluqueriaAnita.Datos.Repositorios
{
    public class AtencionRepositorio
    {
        private readonly Conexion _conexion;

        public AtencionRepositorio()
        {
            _conexion = new Conexion();
        }

        public async Task<List<Atencion>> ObtenerAtencionesAsync()
        {
            var lista = new List<Atencion>();

            try
            {
                using (SqlConnection conn = _conexion.GetConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerAtenciones", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Console.WriteLine("here1");
                                var atencion = new Atencion
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    CitaId = reader.GetInt32(reader.GetOrdinal("CitaId")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    FechaAtencion = reader.GetDateTime(reader.GetOrdinal("FechaAtencion")),
                                    NombreCliente = reader.GetString(reader.GetOrdinal("Nombre")),
                                    FechaHora = reader.GetDateTime(reader.GetOrdinal("FechaHora"))
                                };
                                Console.WriteLine("here2");
                                lista.Add(atencion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear el error si lo necesitas
                
                throw new Exception("Error al obtener atenciones: " + ex.Message);
            }

            return lista;
        }

        // Guardar una nueva atención y actualizar estado de la cita
        public async Task GuardarAtencionAsync(int citaId, string descripcion)
        {
            try
            {
                using (SqlConnection conn = _conexion.GetConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GuardarAtencion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CitaId", citaId);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la atención: " + ex.Message);
            }
        }

    }
}
