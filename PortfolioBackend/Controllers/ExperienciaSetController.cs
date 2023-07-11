using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExperienciaSetController : ControllerBase
    {
        private readonly ILogicaExperiencia logicaExperiencia;
        public ExperienciaSetController(ILogicaExperiencia _logicaExperiencia)
        {
            this.logicaExperiencia= _logicaExperiencia;
        }

        [HttpPost]
        public ActionResult Guardar(List<Experiencia> lista)
        {
            try
            {
                this.logicaExperiencia.Guardar(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject("Se guardo la Experiencia correctamente"));
        }

        [HttpDelete]
        public ActionResult Eliminar(List<Experiencia> lista)
        {
            try
            {
                this.logicaExperiencia.Eliminar(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject("Se ELIMINO la Experiencia correctamente"));
        }
    }
}
