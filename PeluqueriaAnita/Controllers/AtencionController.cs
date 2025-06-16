using Microsoft.AspNetCore.Mvc;
using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeluqueriaAnita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtencionController : ControllerBase
    {
        private readonly AtencionServicio _servicio;

        public AtencionController()
        {
            _servicio = new AtencionServicio();
        }
        // GET: api/Atencion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atencion>>> Get()
        {
            try
            {
                var atenciones = await _servicio.ObtenerAtencionesAsync();
                return Ok(atenciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener atenciones: {ex.Message}");
            }
        }

        // POST: api/Atencion
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Atencion atencion)
        {
            if (atencion == null || atencion.CitaId <= 0 || string.IsNullOrWhiteSpace(atencion.Descripcion))
            {
                return BadRequest("Datos de atención inválidos.");
            }

            try
            {
                await _servicio.GuardarAtencionAsync(atencion.CitaId, atencion.Descripcion);
                return Ok(new { mensaje = "Atención guardada y cita marcada como 'Culminada'." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar la atención: {ex.Message}");
            }
        }

     

        // PUT api/<AtencionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AtencionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
