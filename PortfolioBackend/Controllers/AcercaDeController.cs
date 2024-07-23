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
            AcercaDe acercaDe = this.logicaAcercaDe.Obtener(id);

            return StatusCode(200, JsonConvert.SerializeObject(acercaDe));
        }

        [HttpPost]
        public ActionResult Guardar(AcercaDe acercaDe)
        {
            this.logicaAcercaDe.Guardar(acercaDe);

            return StatusCode(200, JsonConvert.SerializeObject("Se guardo la información correctamente"));
        }

    }
}
