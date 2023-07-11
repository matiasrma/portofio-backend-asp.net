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
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                usuario = this.logicaUsuario.Login(usuario.nombre_usuario, usuario.password);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(usuario));
        }
    }
}
