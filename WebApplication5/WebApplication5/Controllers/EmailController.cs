using Microsoft.AspNetCore.Mvc;
using WebApplication3.Contexto;
using WebApplication4.Models;

namespace WebApplication5.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public EmailController(ILogger<EmailController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Email> GET()
        {
            return _aplicacionContexto.email.ToList();
        }

        [HttpPost]
        [Route("")]
        public IActionResult POST([FromBody] Email newEmail)
        {
            _aplicacionContexto.email.Add(newEmail);
            _aplicacionContexto.SaveChanges();
            return Ok(newEmail);
        }

        [HttpPut]
        [Route("")]
        public IActionResult PUT([FromBody] Email emailUpdate)
        {
            _aplicacionContexto.email.Update(emailUpdate);
            _aplicacionContexto.SaveChanges();
            return Ok(emailUpdate);
        }

        [HttpDelete]
        [Route("")]
        public IActionResult DELETE(int idEmailDelete)
        {
            _aplicacionContexto.email.Remove(_aplicacionContexto.email.ToList().Where(x => x.IdEmail == idEmailDelete).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(idEmailDelete);
        }
    }
}
