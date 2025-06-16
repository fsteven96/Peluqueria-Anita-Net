namespace PeluqueriaAnita.Datos.Modelos
{
    public class Cita
    {
        public int? Id { get; set; }
        public int ClienteId { get; set; }
        public string? NombreCliente { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }



    }
}
