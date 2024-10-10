// Implementa un controlador UsuariosController que soporte las siguientes operaciones:
// ▪ Obtener una lista de todos los usuarios (GET)
// ▪ Obtener un usuario por su ID (GET)
// ▪ Agregar un nuevo usuario (POST)
// ▪ Actualizar un usuario existente (PUT)
// ▪ Eliminar un usuario (DELETE)
using evertectAssesment.Interfaces;
using evertectAssesment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace evertectAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _usuarioService;

        public UsersController(IUser usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> ObtenerTodos()
        {
            var users = _usuarioService.ObtenerTodos().ToList();

            return Ok(users);

        }

        [HttpGet("{id}")]
        public ActionResult<User> ObtenerPorId(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
        [HttpGet("filter")]
        public ActionResult<IEnumerable<User>> FiltrarPorDominio(string dominio)
        {
            try
            {
                var usuariosFiltrados = _usuarioService.FiltrarPorDominio(dominio);
                if (!usuariosFiltrados.Any())
                {
                    return NotFound($"No se encontraron usuarios con el dominio: {dominio}");
                }
                return Ok(usuariosFiltrados);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AgregarUsuario([FromBody] User usuario)
        {
            try
            {

                _usuarioService.AgregarUsuario(usuario);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = usuario.Id }, usuario);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] User usuario)
        {
            if (id != usuario.Id) return BadRequest();
            var existingUser = _usuarioService.GetById(id);
            if (existingUser == null) return NotFound();
            _usuarioService.ActualizarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null) return NotFound();
            _usuarioService.EliminarUsuario(id);
            return NoContent();
        }
    }
}
