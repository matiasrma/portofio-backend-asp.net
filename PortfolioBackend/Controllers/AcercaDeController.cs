using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcercaDeController : ControllerBase
    {
        private readonly ILogicaAcercaDe logicaAcercaDe;
        public AcercaDeController(ILogicaAcercaDe _logicaAcercaDe)
        {
            this.logicaAcercaDe= _logicaAcercaDe;
        }

        [HttpGet]
        public ActionResult AcercaDe(int id)
        {
            AcercaDe acercaDe = new AcercaDe();

            try
            {
                acercaDe = this.logicaAcercaDe.Obtener(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(acercaDe));
        }

        [HttpPost]
        public ActionResult Guardar(AcercaDe acercaDe)
        {
            try
            {
                this.logicaAcercaDe.Guardar(acercaDe);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, "Se guardo la red AcercaDe correctamente");
        }

    }
}
