using Microsoft.AspNetCore.Mvc;
using WebApplication3.Contexto;
using WebApplication4.Models;

namespace WebApplication5.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JuegoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public JuegoController(ILogger<JuegoController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<VideoJuegos> GET()
        {
            return _aplicacionContexto.videoJuego.ToList();
        }

        [HttpPost]
        [Route("")]
        public IActionResult POST([FromBody] VideoJuegos newVideoJuego)
        {
            _aplicacionContexto.videoJuego.Add(newVideoJuego);
            _aplicacionContexto.SaveChanges();
            return Ok(newVideoJuego);
        }

        [HttpPut]
        [Route("")]
        public IActionResult PUT([FromBody] VideoJuegos VideoJuegoUpdate)
        {
            _aplicacionContexto.videoJuego.Update(VideoJuegoUpdate);
            _aplicacionContexto.SaveChanges();
            return Ok(VideoJuegoUpdate);
        }

        [HttpDelete]
        [Route("")]
        public IActionResult DELETE(int idVideoJuegoDelete)
        {
            _aplicacionContexto.videoJuego.Remove(_aplicacionContexto.videoJuego.ToList().Where(x => x.IdVideoJuego == idVideoJuegoDelete).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(idVideoJuegoDelete);
        }
    }
}
