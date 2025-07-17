using System.Data.SqlClient;

namespace PeluqueriaAnita.Datos
{
    public class Conexion
    {
        private const string Conex = "Server=tcp:jsfl.database.windows.net,1433;Initial Catalog=PeluqueriaAnita;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication="Active Directory Default";";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(Conex);
        }
    }
}
