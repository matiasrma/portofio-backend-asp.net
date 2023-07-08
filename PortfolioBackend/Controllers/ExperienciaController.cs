using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienciaController : ControllerBase
    {
        private readonly ILogicaExperiencia logicaExperiencia;
        public ExperienciaController(ILogicaExperiencia _logicaExperiencia)
        {
            this.logicaExperiencia= _logicaExperiencia;
        }

        [HttpGet]
        public ActionResult Experiencia(int persona_id)
        {
            List<Experiencia> lista = new List<Experiencia>();

            try
            {
                lista = this.logicaExperiencia.ObtenerLista(persona_id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(lista));
        }

        [HttpPost]
        public ActionResult Guardar(Experiencia social)
        {
            try
            {
                this.logicaExperiencia.Guardar(social);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, "Se guardo la Experiencia correctamente");
        }

        [HttpDelete]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                this.logicaExperiencia.Eliminar(Id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, "Se ELIMINO la Experiencia correctamente");
        }
    }
}
