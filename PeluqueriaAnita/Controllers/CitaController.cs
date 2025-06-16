using Microsoft.AspNetCore.Mvc;
using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeluqueriaAnita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaServicio _citaServicio;

        public CitaController(CitaServicio citaServicio)
        {
            _citaServicio = citaServicio;
        }

        // GET: api/Cita/activas
        [HttpGet("activas")]
        public async Task<IActionResult> ObtenerCitasActivas()
        {
            try
            {
                List<Cita> citas = await _citaServicio.ObtenerCitasActivasAsync();
                return Ok(citas);
            }
            catch (Exception ex)
            {
                // Log del error (opcional)
                return StatusCode(500, $"Error al obtener las citas activas: {ex.Message}");
            }
        }



        [HttpPost]
        public async Task<IActionResult> CrearCita([FromBody] Cita cita)
        {
            try
            {
                await _citaServicio.AgregarCitaAsync(cita);
                return Ok(new { mensaje = "Cita creada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
