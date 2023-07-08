using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialController : ControllerBase
    {
        private readonly ILogicaSocial logicaSocial;
        public SocialController(ILogicaSocial _logicaSocial)
        {
            this.logicaSocial= _logicaSocial;
        }

        [HttpGet]
        public ActionResult Social(int persona_id)
        {
            List<Social> lista = new List<Social>();

            try
            {
                lista = this.logicaSocial.ObtenerLista(persona_id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(lista));
        }

        [HttpPost]
        public ActionResult Guardar(Social social)
        {
            try
            {
                this.logicaSocial.Guardar(social);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, "Se guardo la red Social correctamente");
        }

        [HttpDelete]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                this.logicaSocial.Eliminar(Id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, "Se ELIMINO la red Social correctamente");
        }
    }
}
