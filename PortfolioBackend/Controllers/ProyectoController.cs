using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly ILogicaProyecto logicaProyecto;
        public ProyectoController(ILogicaProyecto _logicaProyecto)
        {
            this.logicaProyecto= _logicaProyecto;
        }

        [HttpGet]
        public ActionResult Proyecto(int persona_id)
        {
            List<Proyecto> lista = new List<Proyecto>();

            try
            {
                lista = this.logicaProyecto.ObtenerLista(persona_id);
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }

            return StatusCode(200, JsonConvert.SerializeObject(lista));
        }

    }
}
