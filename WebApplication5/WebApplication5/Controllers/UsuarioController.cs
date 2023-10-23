using Microsoft.AspNetCore.Mvc;
using WebApplication3.Contexto;
using WebApplication4.Models;

namespace WebApplication3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        
        public UsuarioController(ILogger<UsuarioController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Usuario> GET()
        {
            return _aplicacionContexto.usuario.ToList();
        }

        [HttpPost]
        [Route("")]
        public IActionResult POST([FromBody] Usuario newDocente)
        {
            _aplicacionContexto.usuario.Add(newDocente);
            _aplicacionContexto.SaveChanges();
            return Ok(newDocente);
        }

        [HttpPut]
        [Route("")]
        public IActionResult PUT([FromBody] Usuario docenteUpdate)
        {
            _aplicacionContexto.usuario.Update(docenteUpdate);
            _aplicacionContexto.SaveChanges();
            return Ok(docenteUpdate);
        }

        [HttpDelete]
        [Route("")]
        public IActionResult DELETE(int idUsuarioDelete)
        {
            _aplicacionContexto.usuario.Remove(_aplicacionContexto.usuario.ToList().Where(x=>x.IdUsuario == idUsuarioDelete).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(idUsuarioDelete);
        }
    }
}
