using System.Data.SqlClient;

namespace PeluqueriaAnita.Datos
{
    public class Conexion
    {
        private const string Conex = "Server=DESKTOP-L1PP6AB\\SQLEXPRESS;Database=PeluqueriaAnita;Trusted_Connection=True;";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(Conex);
        }
    }
}
