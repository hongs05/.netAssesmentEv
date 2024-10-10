using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace evertectAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
