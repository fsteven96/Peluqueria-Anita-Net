using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Datos.Repositorios;

namespace PeluqueriaAnita.Servicios
{
    public class AtencionServicio
    {
        private readonly AtencionRepositorio _repositorio;

        public AtencionServicio()
        {
            _repositorio = new AtencionRepositorio();
        }

        // Servicio para obtener todas las atenciones
        public async Task<List<Atencion>> ObtenerAtencionesAsync()
        {
            try
            {
                return await _repositorio.ObtenerAtencionesAsync();
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes un sistema de logging
                throw new Exception("Error al obtener atenciones desde el servicio: " + ex.Message, ex);
            }
        }

        // Servicio para guardar una atención
        public async Task GuardarAtencionAsync(int citaId, string descripcion)
        {
            try
            {
                await _repositorio.GuardarAtencionAsync(citaId, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar atención desde el servicio: " + ex.Message, ex);
            }
        }
    }
}
