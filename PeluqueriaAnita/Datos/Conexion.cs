using System.Data.SqlClient;

namespace PeluqueriaAnita.Datos
{
    public class Conexion
    {
        private const string Conex = "Server=tcp:servidorsteven.database.windows.net,1433;Initial Catalog=PeluqueriaAnita;Persist Security Info=False;User ID=adminSteven;Password=Soydecristo1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(Conex);
        }
    }
}
