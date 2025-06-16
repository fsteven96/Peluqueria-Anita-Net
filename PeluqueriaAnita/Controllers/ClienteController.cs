using Microsoft.AspNetCore.Mvc;
using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeluqueriaAnita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServicio clienteServicio;

        public ClienteController(ClienteServicio clienteServicio)
        {
            this.clienteServicio = clienteServicio;
        }

        // GET: api/<ClienteController>
        [HttpGet("todosClientes")]
        public IActionResult Get()
        {
            try
            {
                var clientes = clienteServicio.ObtenerTodos();
                return Ok(clientes); // 200 OK con la lista
            }
            catch (Exception ex)
            {
                // Aquí puedes hacer log del error si quieres
                return StatusCode(500, "Error al obtener los clientes: " + ex.Message);
            }
        }

        [HttpPost("agregarCliente")]
        public async Task<IActionResult> AgregarCliente([FromBody] Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                return BadRequest("El nombre del cliente es obligatorio.");

            try
            {
                var resultado = await clienteServicio.AgregarClienteAsync(cliente);

                if (resultado)
                    return Ok("Cliente agregado correctamente.");
                else
                    return StatusCode(500, "No se pudo agregar el cliente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al agregar el cliente: " + ex.Message);
            }
        }


        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
