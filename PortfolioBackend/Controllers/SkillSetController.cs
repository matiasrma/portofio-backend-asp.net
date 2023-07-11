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
    public class SkillSetController : ControllerBase
    {
        private readonly ILogicaSkill logicaSkill;
        public SkillSetController(ILogicaSkill _logicaSkill)
        {
            this.logicaSkill= _logicaSkill;
        }
               
        [HttpPost]
        public ActionResult Guardar(List<Skill> lista)
        {
            try
            {
                this.logicaSkill.Guardar(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }

            return StatusCode(200, JsonConvert.SerializeObject("Se guardo la Skill correctamente"));
        }

        [HttpDelete]
        public ActionResult Eliminar(List<Skill> lista)
        {
            try
            {
                this.logicaSkill.Eliminar(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }

            return StatusCode(200, JsonConvert.SerializeObject("Se ELIMINO la Skill correctamente"));
        }
    }
}
