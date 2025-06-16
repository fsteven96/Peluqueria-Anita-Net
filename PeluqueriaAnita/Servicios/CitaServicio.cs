using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Datos.Repositorios;

namespace PeluqueriaAnita.Servicios
{
    public class CitaServicio
    {
        private readonly CitaRepositorio _citaRepositorio;

        public CitaServicio(CitaRepositorio citaRepositorio)
        {
            _citaRepositorio = citaRepositorio;
        }

        public async Task<List<Cita>> ObtenerCitasActivasAsync()
        {
            return await _citaRepositorio.ObtenerCitasActivasAsync();
        }


        public async Task<bool> AgregarCitaAsync(Cita cita)
        {
            try
            {
                Console.WriteLine(cita.ClienteId);
                Console.WriteLine(cita.FechaHora);
                Console.WriteLine(cita.Estado);
                await _citaRepositorio.AgregarCitaAsync(cita);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al agregar la cita.", ex);
                return false;
            }
        }



    }
}
