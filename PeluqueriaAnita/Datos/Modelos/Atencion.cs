namespace PeluqueriaAnita.Datos.Modelos
{
    public class Atencion
    {
        public int? Id { get; set; }
        public int CitaId { get; set; }
        public string? NombreCliente { get;set; }
        public string Descripcion { get; set; }
        public DateTime FechaAtencion { get; set; }
        public DateTime? FechaHora { get; set; }
    }
}
