using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ILogicaPersona logicaPersona;
        public PersonaController(ILogicaPersona _logicaPersona)
        {
            this.logicaPersona= _logicaPersona;
        }

        [HttpGet]
        public ActionResult Persona(int id)
        {
            Persona persona = new Persona();

            try
            {
                persona = this.logicaPersona.Obtener(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(persona));
        }

        [HttpPost]
        public ActionResult Guardar(Persona persona)
        {
            try
            {
                this.logicaPersona.Guardar(persona);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, "Se guardo la informacion correctamente");
        }

    }
}
