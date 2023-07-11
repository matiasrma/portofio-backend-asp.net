using Dominio;
using ILogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ILogicaSkill logicaSkill;
        public SkillController(ILogicaSkill _logicaSkill)
        {
            this.logicaSkill= _logicaSkill;
        }

        [HttpGet]
        public ActionResult Skill(int persona_id)
        {
            List<Skill> lista = new List<Skill>();

            try
            {
                lista = this.logicaSkill.ObtenerLista(persona_id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(lista));
        }

    }
}
