using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        [HttpGet("GetMet")]
        public ActionResult GetMethod()
        {
            return Ok("Hola Mundo");
        }
    }
}
