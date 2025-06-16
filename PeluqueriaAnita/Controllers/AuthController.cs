using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PeluqueriaAnita.Datos.Modelos;
using PeluqueriaAnita.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeluqueriaAnita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthServicio _authServicio;

        public AuthController()
        {
            _authServicio = new AuthServicio();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario request)
        {
            if (string.IsNullOrWhiteSpace(request.UsuarioNombre) || string.IsNullOrWhiteSpace(request.PasswordU))
                return BadRequest("Usuario y contraseña son requeridos.");

            var usuario = _authServicio.ValidarUsuario(request.UsuarioNombre, request.PasswordU);

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas");

            return Ok(new
            {
                usuario = new
                {
                    usuario.Id,
                    usuario.UsuarioNombre,
                    usuario.NombreCompleto,
                    usuario.Cargo
                }
            });
        }



        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
