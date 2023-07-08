using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogicaUsuario logicaUsuario;
        public LoginController(ILogicaUsuario _logicaUsuario)
        {
            this.logicaUsuario= _logicaUsuario;
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Usuario usuario = new Usuario();

            try
            {
                usuario = this.logicaUsuario.Login(username, password);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(usuario));
        }
    }
}
